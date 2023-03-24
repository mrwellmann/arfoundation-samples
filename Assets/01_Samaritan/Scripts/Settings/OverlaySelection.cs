using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OverlaySelection : MonoBehaviour
{
    [SerializeField]
    private SliderHandleClick transparencySlider;
    [SerializeField]
    private TextMeshProUGUI transparencySliderTextValue;
    [SerializeField]
    private Toggle backGround1;
    [SerializeField]
    private Toggle backGround2;
    [SerializeField]
    private OverlayToggle overlay1;
    [SerializeField]
    private OverlayToggle overlay2;
    [SerializeField]
    private OverlayToggle overlay3;

    private MoveabelOverlay currentOverlay = null;

    private void OnEnable()
    {
        UpdateValues();
    }

    public void Init()
    {
        MoveabelOverlay.MoveabelOverlayCreated += (moveabelOverlay) => { this.currentOverlay = moveabelOverlay; };

        transparencySlider.WhileSliderHandleDown += ChangeTransparency;
        backGround1.onValueChanged.AddListener(SetBackground1);
        backGround2.onValueChanged.AddListener(SetBackground2);

        SetDefaultBackground();
        SetDefaultOverlay();
    }

    private void SetBackground2(bool isOn)
    {
        if (currentOverlay != null)
        {
            currentOverlay.SetBackground2(isOn);
        }
    }

    private void SetBackground1(bool isOn)
    {
        if (currentOverlay != null)
        {
            currentOverlay.SetBackground1(isOn);
        }
    }

    private void UpdateValues()
    {
        UpdateTransparencyText(transparencySlider.slider.value);
    }

    private void SetDefaultBackground()
    {
        backGround1.isOn = false;
        backGround2.isOn = false;

        if (currentOverlay != null)
        {
            currentOverlay.SetBackground1(backGround1.isOn);
            currentOverlay.SetBackground2(backGround2.isOn);
        }
    }

    private void SetDefaultOverlay()
    {
        overlay1.Init();
        overlay2.Init();
        overlay3.Init();
    }

    private void ChangeTransparency(float transpenency)
    {
        UpdateTransparencyText(transpenency);

        if (currentOverlay != null)
        {
            currentOverlay.Transparency = transpenency;
        }
    }

    private void UpdateTransparencyText(float transpenency)
    {
        transparencySliderTextValue.text = transpenency.ToString("0.00");
    }
}