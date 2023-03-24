using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SliderHandleClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Slider slider;
    public event Action<float> WhileSliderHandleDown;

    [SerializeField]
    private bool autoResetToZero = false;
    [SerializeField]
    private bool timeBased = false;

    private bool silderHandelDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == slider.handleRect.gameObject)
        {
            silderHandelDown = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == slider.handleRect.gameObject)
        {
            silderHandelDown = false;
            if (autoResetToZero)
                slider.value = 0;
        }
    }

    private void Update()
    {
        if (silderHandelDown)
        {
            if (timeBased)
            {
                WhileSliderHandleDown.Invoke(slider.value * Time.deltaTime);
            }
            else
            {
                WhileSliderHandleDown.Invoke(slider.value);
            }
        }
    }
}