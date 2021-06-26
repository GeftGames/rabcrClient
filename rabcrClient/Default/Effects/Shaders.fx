Texture2D SpriteTexture;

float Intestity;
float ColorIntestityMultipler;
float StartY;
float EndY;
float2 SourcePosSmoothCorrentor;
float EndSize;
float2 SunAngle;
//float4 ColorTransparent = float4(0, 0, 0, 0);
float4 ColorWhite = float4(1, 1, 1, 1);
float4 ColorBase; 

sampler2D SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR {
	//if (input.TextureCoordinates.y < StartY) return ColorTransparent /*return float4(0,1,0,1)*/;
	//if (input.TextureCoordinates.y > EndY)return ColorTransparent/*return float4(1,0,0,1)*/;
	
	float color;

	// Prepare blur down and up
	float y = input.TextureCoordinates.y + SourcePosSmoothCorrentor.y;
	if (y-StartY < EndSize)  color = tex2D(SpriteTextureSampler, input.TextureCoordinates + SourcePosSmoothCorrentor).r*smoothstep(0.0, 1.0, (y-StartY)/EndSize);
	else if (y > EndY-EndSize)  color = tex2D(SpriteTextureSampler, input.TextureCoordinates + SourcePosSmoothCorrentor).r * smoothstep(0.0, 1.0, (EndY - y) / EndSize);
	else color = tex2D(SpriteTextureSampler, input.TextureCoordinates + SourcePosSmoothCorrentor).r;
	
	// Compute intensity
	float c = (color - Intestity)*(1.0/(1.0-Intestity));

	// Compute sun colorize
	float2 secondPos = input.TextureCoordinates + SourcePosSmoothCorrentor + SunAngle;

	float colorSun;

	// Prepare blur down and up
	if (secondPos.y-StartY < EndSize) {
		colorSun = tex2D(SpriteTextureSampler, secondPos).r*smoothstep(0.0, 1.0, (secondPos.y-StartY)/EndSize);
	} else if (secondPos.y > EndY-EndSize) {
		colorSun = tex2D(SpriteTextureSampler, secondPos).r*smoothstep(0.0, 1.0, (EndY-secondPos.y)/EndSize);
	} else colorSun = tex2D(SpriteTextureSampler, secondPos).r;
	
	float c2 = (colorSun - Intestity)*(1.0/(1.0-Intestity));
	
	float changer=colorSun-color;
	
	float z=(c+c2)*0.5f;
	if (changer<0) {
		return ColorBase*z;
	} else {
		float ch=saturate(changer*ColorIntestityMultipler);
		return (ColorBase*(1-ch)+input.Color*ch)*z;
	}
}

technique SpriteDrawing {
	pass P0	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};