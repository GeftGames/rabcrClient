#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

#define SAMPLE_COUNT 16

float2 SampleOffsets[SAMPLE_COUNT];
float SampleWeights[SAMPLE_COUNT];

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
    float4 color = float4(0, 0, 0, 0);

    for (int i = 0; i < SAMPLE_COUNT; i++)
        color += tex2D(SpriteTextureSampler, input.TextureCoordinates + SampleOffsets[i]) * SampleWeights[i];

    return color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};