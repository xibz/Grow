Shader "RenderFX/Skybox Blended Fog" {
    Properties {
        //_Tint ("Tint Color", Color) = (.5, .5, .5, .5)
        _MultiplyColor ("Multiply Color", Color) = (1, 1, 1, 1)
        _FogTint ("Fog Tint", Color) = (.5, .5, .5, .5)
        _FrontTex ("Front (+Z)", 2D) = "white" {}
        _BackTex ("Back (-Z)", 2D) = "white" {}
        _LeftTex ("Left (+X)", 2D) = "white" {}
        _RightTex ("Right (-X)", 2D) = "white" {}
        _UpTex ("Up (+Y)", 2D) = "white" {}
        _DownTex ("Down (-Y)", 2D) = "white" {}
        //_FrontTex2("2 Front (+Z)", 2D) = "white" {}
        //_BackTex2("2 Back (-Z)", 2D) = "white" {}
        //_LeftTex2("2 Left (+X)", 2D) = "white" {}
        //_RightTex2("2 Right (-X)", 2D) = "white" {}
        //_UpTex2("2 Up (+Y)", 2D) = "white" {}
        //_DownTex2("2 Down (-Y)", 2D) = "white" {}
        _FogSideMask("Side FogMask", 2D) = "black" {}
        //_FogBottom("Bottom FogMask", 2D) = "white" {}
    }
    SubShader {
        Tags { "Queue" = "Background" }
        Cull Off
        Fog { Mode Off }
        Lighting Off        
        Color [_Tint]
        Pass {
            SetTexture [_FrontTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_FrontTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
            SetTexture [_FogSideMask] { constantColor[_FogTint] combine constant lerp (texture) previous }
        }
        Pass {
            SetTexture [_BackTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_BackTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
            SetTexture [_FogSideMask] { constantColor[_FogTint] combine constant lerp (texture) previous }
        }
        Pass {
            SetTexture [_LeftTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_LeftTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
            SetTexture [_FogSideMask] { constantColor[_FogTint] combine constant lerp (texture) previous }
        }
        Pass {
            SetTexture [_RightTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_RightTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
            SetTexture [_FogSideMask] { constantColor[_FogTint] combine constant lerp (texture) previous }
        }
        Pass {
            SetTexture [_UpTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_UpTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
        }
        Pass {
            SetTexture [_DownTex] { constantColor[_MultiplyColor] combine texture * constant }
            //SetTexture [_DownTex2] { constantColor[_Tint] combine texture lerp(constant) previous }
            //SetTexture [_FogBottom] { constantColor[_FogTint] combine constant lerp (texture) previous }
        }
    }
    Fallback "RenderFX/Skybox", 1
}