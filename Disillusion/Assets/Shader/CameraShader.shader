
Shader "Unlit/WaveWarp"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_NoiseTex("Noise (RGB)", 2D) = "white" {}
		_UVScale("uv scale ", Range(0.0, 1.0)) = 1.0
		_NoiseTimeScale("Noise Time Scale ", Range(0,1)) = 1
		_OverlayTex("Overlay (RGB)", 2D) = "white" {}
		_OverlayAlpha("Overlay Alpha" , Range(0.0,1.0)) = 0
	}
		SubShader
	{
		Pass{
			CGPROGRAM
			#pragma vertex vert_img  
			#pragma fragment frag  

			#include "UnityCG.cginc"  

			uniform sampler2D _MainTex;
			uniform sampler2D _NoiseTex;
			uniform sampler2D _OverlayTex;
			float _OverlayAlpha;
			fixed _UVScale;
			float _NoiseTimeScale;

			fixed4 frag(v2f_img i) : COLOR
			{
				float4 noise = tex2D(_NoiseTex, i.uv - _Time.xy * _NoiseTimeScale);
				float2 offset = noise.xy * _UVScale;
				float4 MainColor = tex2D(_MainTex, i.uv);
				//float4 tmp = (MainColor * _OverlayAlpha);
				//float4 tmp2 = (tex2D(_OverlayTex, i.uv + offset) * (1.0 - _OverlayAlpha));
				//return tmp + tmp2.rgba;
				return ( (MainColor * _OverlayAlpha) + (tex2D(_OverlayTex, i.uv + offset) * (1.0 - _OverlayAlpha)));
			}
			ENDCG
		}
	}
		FallBack "Diffuse"

}