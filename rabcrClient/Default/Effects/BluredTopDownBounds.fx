//#if OPENGL
//	#define SV_POSITION POSITION
//	#define VS_SHADERMODEL vs_3_0
//	#define PS_SHADERMODEL ps_3_0
//#else
//	#define VS_SHADERMODEL vs_4_0_level_9_1
//	#define PS_SHADERMODEL ps_4_0_level_9_1
//#endif

Texture2D SpriteTexture;
float pos;
float v;
float alpha;

sampler2D SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput {
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR {
	//float2 py = input.TextureCoordinates.y;
	//float2 px = input.TextureCoordinates.x;
	float4 wa = float4(1,1,1,1)*0.75f*alpha;
    if (input.TextureCoordinates.y >= pos) {
        if (input.TextureCoordinates.y <= 1-pos) {
            float4 color=tex2D(SpriteTextureSampler, input.TextureCoordinates);
            //return (color+float4(1,1,1,1)*0.75f*(1-color.a))*alpha;
			return (color*alpha + wa*(1 - color.a));
        } else { 
			float a=(1-input.TextureCoordinates.y)/pos;
			//float4 blur = 0;
			//float totaladda = 0;
			float4 c5 = tex2D(SpriteTextureSampler, input.TextureCoordinates);
			//
			//blur += c5;
			//totaladda+=1;

			//float blur1a = (1-a)*3;
			//if (blur1a>1) blur1a = 1;

			//float4 c2 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v));
			//float4 c4 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, 0));
			//float4 c6 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, 0));
			//float4 c8 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v));

			//blur += (c2 + c4 + c6 + c8)/4*blur1a;

			//totaladda += blur1a;
		
			//if (blur1a == 1) {
			//	float blur2a = (1 - a) * 3 - 0.33f;
			//	if (blur2a > 1) blur2a = 1;

			//	float4 c1 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, -v));
			//	float4 c3 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, v));
			//	float4 c7 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, -v));
			//	float4 c9 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, v));

			//	blur += (c2 + c4 + c6 + c8)/4*blur2a;
			//	totaladda += blur2a;

			//	if (blur2a == 1) {
			//		float blur3a = (1 - a) * 3 - 0.66f;
			//		//if (blur2a > 1) blur2a = 1;

			//		float4 c22 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v * 2));
			//		float4 c44 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v * 2, 0));
			//		float4 c66 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v * 2, 0));
			//		float4 c88 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v * 2));

			//		blur += (c2 + c4 + c6 + c8)/4*blur3a;
			//		totaladda += blur3a;
			//	}	
			//}
            //Down
          /*  float4 c2 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v));
            float4 c4 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, 0));
            float4 c6 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, 0));
            float4 c8 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v));

            float4 c1 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, -v));
            float4 c3 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, v));
            float4 c7 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, -v));
            float4 c9 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, v));
*/
            


         /*   float4 c22 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v * 2));
            float4 c44 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v * 2, 0));
            float4 c66 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v * 2, 0));
            float4 c88 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v * 2));
*/
           
            //float4 blur=((c2 + c4 + c6 + c8) / 4) * 0.45f + ((c1 + c3 + c7 + c9) / 4) * 0.35f + ((c22 + c44 + c66 + c88) / 4) * 0.2f;
            //return (/*(c5*a  +*/ (blur/ totaladda)/**(1-a)*/*a/*(1-a)*//*)*a*/+float4(1,1,1,1)*0.75f*(1-c5.a)*a)*alpha;

			//return (c5*a  + float4(1, 1, 1, 1)*0.75f*(1 - c5.a)*a)*alpha;
			return (c5*alpha + wa*(1 - c5.a))*a;
        }
    } else {
		float2 p = input.TextureCoordinates;
	 /*//	float xc = input.TextureCoordinates.x + v;
		
        //Up
       float4 c2 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v));
        float4 c4 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, 0));
        float4 c6 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, 0));
        float4 c8 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v));

        float4 c1 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, -v));
        float4 c3 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, v));
        float4 c7 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, -v));
        float4 c9 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, v));

        float4 c5 = tex2D(SpriteTextureSampler, input.TextureCoordinates);


        float4 c22 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v * 2));
        float4 c44 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v * 2, 0));
        float4 c66 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v * 2, 0));
        float4 c88 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v * 2));*/

		/*float4 c2 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v));
		float4 c4 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, 0));
		float4 c6 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, 0));
		float4 c8 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v));

		float4 c1 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, -v));
		float4 c3 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v, v));
		float4 c7 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, -v));
		float4 c9 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v, v));
*/
		float4 c5 = tex2D(SpriteTextureSampler, input.TextureCoordinates);


		/*float4 c22 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, -v * 2));
		float4 c44 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(-v * 2, 0));
		float4 c66 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(v * 2, 0));
		float4 c88 = tex2D(SpriteTextureSampler, input.TextureCoordinates + float2(0, v * 2));
*/
        float a=input.TextureCoordinates.y/pos;
		//float4 blur1 = (/*(*/
		//	c2
		//	+ c4
		//	+ c6
		//	+ c8

		//	) * 0.1125f;

		//float4 blur=blur1+
		///*/ 4) * 0.45f */+ ((c1 + c3 + c7 + c9) / 4) * 0.35f + ((c22 + c44 + c66 + c88) / 4) * 0.2f;
     //   return ((c5*a /*+ blur*(1-a)*/)*a+float4(1,1,1,1)*0.75f*(1-c5.a)*a)*alpha; 

		return (c5*alpha + wa * (1 - c5.a))*a;
    }
}

technique SpriteDrawing {
	pass P0	{
		//PixelShader = compile PS_SHADERMODEL MainPS();
		//PixelShader = compile ps_3_0 MainPS();
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};