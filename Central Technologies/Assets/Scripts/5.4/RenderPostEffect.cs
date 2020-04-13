using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DOF
{
    public class RenderPostEffect : MonoBehaviour
    {
        public bool isDepthEnable = false;
        public Material renderMaterial;
        public Shader replaceShader;

        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
            if(cam != null && isDepthEnable)
            {
                cam.depthTextureMode |= DepthTextureMode.Depth;
            }
        }

        private void LateUpdate()
        {
            if(cam != null && replaceShader != null)
            {
                cam.RenderWithShader(replaceShader, "RenderType");
            }
        }

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
}
