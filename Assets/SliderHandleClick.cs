using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SliderHandleClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Slider slider;
    public event Action<float> WhileSliderHandleDown;
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
        }
    }

    private void Update()
    {
        if (silderHandelDown)
            WhileSliderHandleDown.Invoke(slider.value * Time.deltaTime);
    }
}