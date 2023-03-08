using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class OverlayPositioning : MonoBehaviour
{
    [SerializeField]
    private SliderHandleClick distanceSlider;
    [SerializeField]
    private TextMeshProUGUI distanceSliderTextValue;
    [SerializeField]
    private SliderHandleClick scaleSlider;
    [SerializeField]
    private TextMeshProUGUI scaleSliderTextValue;
    [SerializeField]
    private Toggle lookAt;

    private void Start()
    {
        lookAt.onValueChanged.AddListener(SetLookAt);
        distanceSlider.WhileSliderHandleDown += ChangeDistanceInMeter;
        scaleSlider.WhileSliderHandleDown += ChangeScale;
    }

    private void ChangeDistanceInMeter(float delta)
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        moveabelOverlay.ChageDistanceToCamera = delta;
        distanceSliderTextValue.text = (moveabelOverlay.transform.position - Camera.main.transform.position).magnitude.ToString("0");
    }

    private void ChangeScale(float delta)
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        moveabelOverlay.ChangeScale = delta;
        scaleSliderTextValue.text = moveabelOverlay.transform.localScale.x.ToString("0.0");

    }

    private void SetLookAt(bool isOn)
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        moveabelOverlay.GetComponentInChildren<LookAt>().enabled = isOn;
    }
}