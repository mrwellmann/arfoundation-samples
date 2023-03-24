using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum OverlayType
{
    Overlay1,
    Overlay2,
    Overlay3
}

public enum OverlayYear
{
    None,
    Y2012,
    Y2022
}

public class ImageOverlay : MonoBehaviour
{
    [FormerlySerializedAs("overlayImage")]
    public Image OverlayImage;
    public OverlayType CurrentOverlayType;
    public OverlayYear SetOverlayYear;
    public bool fade;
    public bool fill;

    public float Transparency
    {
        get
        {
            float alpha = 0;
            if (OverlayImage != null)
            {
                alpha = OverlayImage.color.a;
            }
            else
            {
                var material = GetComponentInChildren<Material>();
                if (material != null)
                {
                    alpha = material.color.a;
                }
            }
            return alpha;
        }
        set
        {
            if (OverlayImage != null)
            {
                OverlayImage.color = new Color(OverlayImage.color.r, OverlayImage.color.g, OverlayImage.color.b, value);
                return;
            }
            var meshRenderer = GetComponentInChildren<MeshRenderer>();
            if (meshRenderer.materials.Length > 0 && meshRenderer.materials[0] != null)
            {
                var material = meshRenderer.materials[0];
                if (material != null)
                {
                    material.color = new Color(material.color.r, material.color.g, material.color.b, value);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //modify fill / alpha with touch
        //if (Input.touchCount > 0)
        //{
        //    var touchZero = Input.GetTouch(0);
        //    float yPosRelativeToScreenSzize = 0;
        //    if (touchZero.position.y != 0)
        //        yPosRelativeToScreenSzize = touchZero.position.y / Screen.height;

        //    if (OverlayImage != null)
        //    {
        //        if (fill)
        //            OverlayImage.fillAmount = yPosRelativeToScreenSzize;
        //        else
        //            OverlayImage.fillAmount = 1;
        //        if (fade)
        //            OverlayImage.color = new Color(OverlayImage.color.r, OverlayImage.color.g, OverlayImage.color.b, yPosRelativeToScreenSzize);
        //        else
        //            OverlayImage.color = new Color(OverlayImage.color.r, OverlayImage.color.g, OverlayImage.color.b, 1);
        //    }

        //    Debug.Log("yPosRelativeToScreenSzize: " + yPosRelativeToScreenSzize);
        //    Debug.Log("touchZero: " + touchZero.position);
        //}
    }

    public void UseFade(bool isOn)
    {
        fade = !fade;
    }

    public void UseFill(bool isOn)
    {
        fill = !fill;
    }
}