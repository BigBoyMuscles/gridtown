// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "HoverTileShader"
{
	Properties
	{
		_MainTex("Albedo Texture", 2D) = "white" {}
		_TintColor("Tint Color", Color) = (1,1,1,1)
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25
		_CutoutThresh("Cutout Threshold", Range(0.0,1.0)) = 0.2
		_Distance("Distance", Float) = 1
		_Amplitude("Amplitude", Float) = 1
		_Speed("Speed", Float) = 1
		_Amount("Amount", Range(0.0,1.0)) = 1
	}
	SubShader
	{
		Tags
	{
		"Queue" = "Transparent" "RenderType" = "Transparent"

	}		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		Pass
	{
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag

	#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex : SV_POSITION;
		float2 uv : TEXCOORD0;
	};

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = v.uv;
		return o;
	}

	float4 frag(v2f i) : SV_TARGET
	{
		return float4(.992, 1, .565, 1);
	}
		ENDCG
	}
	}
}