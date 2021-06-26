//#if OPENGL
//	#define SV_POSITION POSITION
//	#define VS_SHADERMODEL vs_3_0
//	#define PS_SHADERMODEL ps_3_0
//#else
//	#define VS_SHADERMODEL vs_4_0_level_9_1
//	#define PS_SHADERMODEL ps_4_0_level_9_1
//#endif

#define SAMPLE_COUNT 16

Texture2D SpriteTexture;

sampler2D SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR {

    // Color of pixel
    float4 sourceColor=tex2D(SpriteTextureSampler, input.TextureCoordinates);
        
    // Do not count with transparent = waste of time
    if (sourceColor.a==0) return 0;
   
    // Light of color
    float d=sourceColor.a * (sourceColor.r+sourceColor.g+sourceColor.b)/6;
    
    // Prepare color (without alpha)
    float4 c=float4 (
        sourceColor.r+(1-sourceColor.r)*d,
        sourceColor.g+(1-sourceColor.g)*d,
        sourceColor.b+(1-sourceColor.b)*d,
    
        sourceColor.a
    );

    // return
    return c*sourceColor.a*input.Color.a;
}

technique SpriteDrawing {
	pass P0	{
		PixelShader = compile /*PS_SHADERMODEL*/ps_4_0_level_9_1 MainPS();
	}
};