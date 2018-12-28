﻿using System.Collections.Generic;
using UnityEngine;

public class ChromaKey_Alpha_General : MSKComponentBase
{
	[SerializeField]
	private Color _keyColor = Color.green;
	public Color keyColor {
		get { return _keyColor; }
		set { if (SetStruct(ref _keyColor, value)) _shaderMaterial.SetColor("_KeyColor", value); }
	}

	[SerializeField, Range(0.0f, 1.0f), Tooltip("Chroma max difference")]
	private float _dChroma = 0.5f;
	public float dChroma {
		get { return _dChroma; }
		set { if (SetStruct(ref _dChroma, value)) _shaderMaterial.SetFloat("_DChroma", value); }
	}

	[SerializeField, Range(0.0f, 1.0f), Tooltip("Chroma tolerance")]
	private float _dChromaT = 0.05f;
	public float dChromaT {
		get { return _dChromaT; }
		set { if (SetStruct(ref _dChromaT, value)) _shaderMaterial.SetFloat("_DChromaT", value); }
	}

	[SerializeField, Range(0.0f, 1.0f), Tooltip("Luma max difference")]
	private float _dLuma = 0.5f;
	public float dLuma {
		get { return _dLuma; }
		set { if (SetStruct(ref _dLuma, value)) _shaderMaterial.SetFloat("_DLuma", value); }
	}

	[SerializeField, Range(0.0f, 1.0f), Tooltip("Luma tolerance")]
	private float _dLumaT = 0.05f;
	public float dLumaT {
		get { return _dLumaT; }
		set { if (SetStruct(ref _dLumaT, value)) _shaderMaterial.SetFloat("_DLumaT", value); }
	}
	
	private RenderTexture _rtC; //render texture Chroma

	private List<string> _availableShaders = new List<string>() { @"MSK/ChromaKey/BlendOff/ChromaKey_Alpha_General" };
	public override List<string> GetAvailableShaders() {
		return _availableShaders;
	}

	public override void UpdateShaderProperties() {
		_shaderMaterial.SetColor("_KeyColor", _keyColor);
		_shaderMaterial.SetFloat("_DChroma", _dChroma);
		_shaderMaterial.SetFloat("_DChromaT", _dChromaT);
		_shaderMaterial.SetFloat("_DLuma", _dLuma);
		_shaderMaterial.SetFloat("_DLumaT", _dLumaT);
	}

	public override void UpdateSourceTexture() {
		RenderTextureUtils.SetRenderTextureSize(ref _rtC, _mskController.sourceTexture.width, _mskController.sourceTexture.height);
	}

	public override RenderTexture GetRender(Texture src) {
		_rtC.DiscardContents();
		Graphics.Blit(src, _rtC, _shaderMaterial);
		return _rtC;
	}

	protected override void OnDestroy() {
		base.OnDestroy();
		if(_rtC != null) {
			DestroyImmediate(_rtC);
		}
	}
}