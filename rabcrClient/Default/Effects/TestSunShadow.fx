float angleSin;
float angleCos;
float alpha;
float weight[5];

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};


float4 ComputeMaxLighting(VertexShaderOutput input) : COLOR {

	float2 coords=input.TextureCoordinates;
	float4 color=tex2D(SpriteTextureSampler, coords);
	
	float ConpInt = color.b*weight[0];

	float s=angleSin;
	float c=angleCos;

	for (int i = 1; i < 5; i++) {
		float2 vec=float2(c*i, s*i)*2.0f;

		float2 actualPos = coords - vec;
		float2 actualPos2 = coords + vec;
		
		float actualColor = tex2D(SpriteTextureSampler, actualPos).r;
		float actualColor2 = tex2D(SpriteTextureSampler, actualPos2).r;

		ConpInt += (actualColor + actualColor2) * weight[i];
	}
	

	float FragmentColor = color.a*weight[0];
	float intenzity=(ConpInt*0.5+0.1);
	//s*=intenzity;
	//c*=intenzity;

	for (int j = 1; j < 5; j++) {
		float2 vec=float2(c*j, s*j)*2.0f;

		float2 actualPos = coords - vec;
		float2 actualPos2 = coords + vec;

		float actualColor = tex2D(SpriteTextureSampler, actualPos).a;
		float actualColor2 = tex2D(SpriteTextureSampler, actualPos2).a;

		FragmentColor += (actualColor+actualColor2) * weight[j];
	}

	//for (int k = 1; k < 5; k++) {
	//	float2 actualPos=coords+float2(-i*distanceW*2,0);
	//	float actualColor=tex2D(SpriteTextureSampler, actualPos).a;
	//	FragmentColor+=actualColor*weight[k];
	//}
	//for (int z = 1; z < 5; z++) {
	//	float2 actualPos=coords+float2(i*distanceW*2,0);
	//	float actualColor=tex2D(SpriteTextureSampler, actualPos).a;
	//	FragmentColor+=actualColor*weight[z];
	//}

	//float s=sin(color.a*10)*0.1+0.1;
	
	return float4(0,0,0,FragmentColor*0.2f*alpha+color.a*0.05f);
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile ps_4_0_level_9_1 ComputeMaxLighting();
	}
};