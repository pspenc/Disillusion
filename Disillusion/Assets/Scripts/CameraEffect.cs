using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraEffect : MonoBehaviour
{
    public Texture noiseTexure;
    public Texture OverlayTexture;
    [Range(0.0f, 1.0f)]
    public float noiseTimeScale = 1.0f;
    [Range(0.0f, 1.0f)]
    public float uvScale = 0.15f;
    public Shader shader = null;
    private Material _material = null;
    public Material _Material
    {
        get
        {
            if (_material == null)
                _material = GenerateMaterial(shader);
            return _material;
        }
    }
    protected Material GenerateMaterial(Shader shader)
    {
        if (shader == null)
            return null;
        if (shader.isSupported == false)
            return null;
        Material material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        if (material)
            return material;
        return null;
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        if (_Material != null)
        {
            _Material.SetFloat("_UVScale", uvScale);
            _Material.SetFloat("_NoiseTimeScale", noiseTimeScale);
            _Material.SetTexture("_NoiseTex", noiseTexure);
            _Material.SetTexture("_OverlayTex", OverlayTexture);
            _Material.SetFloat("_OverlayAlpha", 0.99f);
            Graphics.Blit(sourceTexture, destTexture, _Material);
        }
        else
        {
            Graphics.Blit(sourceTexture, destTexture);
        }
    }


    void OnDisable()
    {
        if (_material != null)
        {
            DestroyImmediate(_material);
        }
    }

}

