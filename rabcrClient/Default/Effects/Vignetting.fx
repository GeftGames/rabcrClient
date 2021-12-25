float WSize; // half window width if bigger than height than with height salt
float HSize; // half window height if bigger than width than with width salt
float Intensity;

sampler2D SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR {
	float x;
	float y;
	
	if (input.TextureCoordinates.x < 0.5f) x = (0.5f-input.TextureCoordinates.x) * WSize;
	else x = (input.TextureCoordinates.x-0.5f) * WSize;
	
	if (input.TextureCoordinates.y < 0.5f) y = (0.5f-input.TextureCoordinates.y) * HSize;
	else y = (input.TextureCoordinates.y - 0.5f) * HSize;

	return float4(0, 0, 0, Intensity * (y*y + x*x));
}

technique SpriteDrawing {
	pass P0	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};