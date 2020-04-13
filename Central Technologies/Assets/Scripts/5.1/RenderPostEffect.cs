using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPostEffect : MonoBehaviour
{
    public Material renderMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(renderMaterial != null)
        {
            Graphics.Blit(source, destination, renderMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
