using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum OverlayType
{
    Overlay1,
    Overlay2,
    Overlay3,
    Background
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

    // Start is called before the first frame update
    private void Start()
    {
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