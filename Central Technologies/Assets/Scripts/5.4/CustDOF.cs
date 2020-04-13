using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CustDOF : MonoBehaviour
{
    public Material _BlurMaterial;
    public Material _DOFMaterial;
    [Range(0, 1)]
    public float focalDistance = 0.5f;
    [Range(0.0f, 100.0f)]
    public float scaleParam = 30.0f;
    public int downSample = 1;

    private void OnEnable()
    {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
    }

    private void OnDisable()
    {
        GetComponent<Camera>().depthTextureMode &= ~DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture blurTex = RenderTexture.GetTemporary(source.width >> downSample, source.height >> downSample, 0, source.format);

        Graphics.Blit(source, blurTex, _BlurMaterial);

        _DOFMaterial.SetTexture("_BlurTex", blurTex);
        _DOFMaterial.SetFloat("_focalDistance", focalDistance);
        _DOFMaterial.SetFloat("_scaleParam", scaleParam);

        Graphics.Blit(source, destination, _DOFMaterial);
        RenderTexture.ReleaseTemporary(blurTex);
    }
}
