Texture2D SpriteTexture;
//float4 ColorWhite = float4(1, 1, 1, 1);
float Time;
float PosX;
float PosY;
float Opacity=1;
float4 Color;

sampler2D SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float rand(float2 vec) {
	  return frac(sin(dot(vec, float2(/*56*/56, 78/*78*/)) /**1.0*/) * 1000.0);
	//return frac(sin(dot(vec, float2(12.9898, 78.233))) * 43758.5453);
	//return 1.0;
}

float noise(float2 pos) {
	float2 i = floor(pos);
	float2 f = frac(pos);

	float a = rand(i);
	float b = rand(i+float2(1.0,0.0));
	float c = rand(i+float2(0.0,1.0));
	float d = rand(i+float2(1.0,1.0));

	float2 cubic = f*f*(3-2*f);
	return lerp(a, b, cubic.x) + (c-a)*cubic.y *(1.0-cubic.x)+(d-b)*cubic.x*cubic.y;
}

float fbm(float2 coord) {
	float value=0.0;
	float scale=0.5;

	for (int i = 0; i < 3/*Octaves*/; i++) {
		value+=noise(coord) *scale;
		coord*=2.0;
		scale*=0.4;
	}
	return value;
}

float4 MainPS(VertexShaderOutput input) : COLOR {
	float2 coord = input.TextureCoordinates*5.0+float2(PosX,PosY);
	float motion = fbm(coord+float2(Time,Time/4));
	float final = fbm(coord+motion);

	//return float4(final, final, final, 1);
	return Color*final*Opacity;
}

technique SpriteDrawing {
	pass P0	{
		PixelShader = compile /*ps_4_0_level_9_1*/ps_4_0_level_9_3 MainPS();
		//VertexShader = compile vs_5_0 VertexShaderFunction();
	}
};
/*
float4 PixelshaderFunc(float4 pos : SV_POSITION, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
    float4 pixelShift = ScreenTexture.Sample(LinearSampler, texCoord.xy + float2(0.1f, 0.0f));
    return pixelShift; 
}*/