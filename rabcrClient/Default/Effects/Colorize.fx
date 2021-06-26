//#if OPENGL
//	#define SV_POSITION POSITION
//	#define VS_SHADERMODEL vs_3_0
//	#define PS_SHADERMODEL ps_3_0
//#else
//	#define VS_SHADERMODEL vs_4_0_level_9_1
//	#define PS_SHADERMODEL ps_4_0_level_9_1
//#endif

//#define SAMPLE_COUNT 16

Texture2D SpriteTexture;

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

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float4 color=tex2D(SpriteTextureSampler, input.TextureCoordinates);
    if (color.a==0) return color;

    return (input.Color*color.r+float4(input.Color.r/3, input.Color.g/3, input.Color.b/3, 1-color.r))*color.a;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};