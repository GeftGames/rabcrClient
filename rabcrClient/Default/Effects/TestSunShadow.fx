Texture2D SpriteTexture;
texture2D ShadowTexture; 
float Height;
//float starts [Height];
float Bevel;
float3x4 WorldViewProjection;
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

//float4 MainPS(VertexShaderOutput input) : COLOR
//{
//    float4 color=tex2D(SpriteTextureSampler, input.TextureCoordinates);
//    if (color.a==0) return color;

//    return (input.Color*color.r+float4(input.Color.r/3, input.Color.g/3, input.Color.b/3, 1-color.r))*color.a;
//}

float4 ComputeMaxLighting(VertexShaderOutput input) : COLOR
{
	//float2 coords=input.TextureCoordinates;
	////float2 coordsE=float2(coords.x+coords.y*Bevel,coords.y);

 //   float4 color=tex2D(SpriteTextureSampler, coords);
 //  // float4 color0=tex2D(SpriteTextureSampler, float2(0,0));
	////float source=color.r;

 //   //float2 posLast=coords;
	////posLast.y+=Height;
	
 //  // float4 colorP=tex2D(SpriteTextureSampler, posLast);
	//float source=color.r;
	//int index=(int)(coords.x*Height);
	//float inArray=starts[index];
	//if (source>inArray) starts[index]=coords.y;


 //   return float4(input.Color.r, z, colorP.r, 1);

	float2 coords=input.TextureCoordinates;
	float2 vectorLight=float2(Bevel,1);
	float bestColor=1.0;
	float distance=Height*50;
	for (int i = 0; i < 1; i++) {
		float2 actualPos=coords-i*vectorLight*distance;
		float4 color=tex2D(SpriteTextureSampler, actualPos);
		if (color.r<bestColor)bestColor=color.r;
	}
	return float4(bestColor, bestColor, bestColor, bestColor);
}

//struct VS_OUTPUT
//{
//    float4 Pos  : POSITION;
//    float2 Tex  : TEXCOORD0;
//};
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
    float3 color : COLOR;
};
struct v2p
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
    float3 color : TEXCOORD1;
};
//float2 UVTile;
v2p VS(vertexInfo input/*float3 InPos  : POSITION, float2 InTex  : TEXCOORD0*/) {
//    VS_OUTPUT Out = (VS_OUTPUT)0;

//    // transform the position to the screen
//	Out.Pos =mul(WorldViewProjection, float4(InPos,1.0));//mul(InPos, WorldViewProjection);

//    //Out.Pos = float4(InPos,1) + float4(-TextureDimensions.x, TextureDimensions.y, 0, 0);
////    Out.Pos =InPos;///* float4(InPos,1) + */float4(1-TextureDimensions.x, TextureDimensions.y, 0, 0);
//    Out.Tex = InTex;

//    return Out;

	//v2p output;
 //   output.position = mul(WorldViewProjection, float4(input.position,1.0));
 //   output.uv = input.uv * UVTile;
 //   output.color = input.color;
	v2p output;
output.position = input.position;
output.color = input.color;
output.uv = input.uv;

return output;

    //return output;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile ps_4_0_level_9_1 ComputeMaxLighting();
		VertexShader = compile vs_4_0_level_9_1 VS();
	}
};