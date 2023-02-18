using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOverlay : MonoBehaviour
{
    public Image overlayImage;
    public bool fade;
    public bool fill;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touchZero = Input.GetTouch(0);
            float yPosRelativeToScreenSzize = 0;
            if (touchZero.position.y != 0)
                yPosRelativeToScreenSzize = touchZero.position.y / Screen.height;

            if (overlayImage != null)
            {
                if (fill)
                    overlayImage.fillAmount = yPosRelativeToScreenSzize;
                else
                    overlayImage.fillAmount = 1;
                if (fade)
                    overlayImage.color = new Color(overlayImage.color.r, overlayImage.color.g, overlayImage.color.b, yPosRelativeToScreenSzize);
                else
                    overlayImage.color = new Color(overlayImage.color.r, overlayImage.color.g, overlayImage.color.b, 1);
            }

            Debug.Log("yPosRelativeToScreenSzize: " + yPosRelativeToScreenSzize);
            Debug.Log("touchZero: " + touchZero.position);
        }
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