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
    [SerializeField]
    private Toggle dragAndDrop;
    [SerializeField]
    private Button centerToView;

    private void Start()
    {
        distanceSlider.WhileSliderHandleDown += ChangeDistanceInMeter;
        scaleSlider.WhileSliderHandleDown += ChangeScale;
        centerToView.onClick.AddListener(CenterToView);
        lookAt.onValueChanged.AddListener(SetLookAt);
        dragAndDrop.onValueChanged.AddListener(SetDragAndDrop);

        SetLookAt(lookAt.isOn);
        SetDragAndDrop(dragAndDrop.isOn);
    }

    private void CenterToView()
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        moveabelOverlay.MoveToPositionKeepDisctanceToCamera();
    }

    private void ChangeDistanceInMeter(float delta)
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        moveabelOverlay.ChageDistanceToCamera = delta;

        distanceSliderTextValue.text = Vector3.Distance(moveabelOverlay.transform.position, Camera.main.transform.position).ToString("0.0");
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
        //moveabelOverlay.transform.rotation.SetEulerAngles(moveabelOverlay.transform.rotation.eulerAngles.x, moveabelOverlay.transform.rotation.eulerAngles.y, 0);
        moveabelOverlay.transform.rotation = Quaternion.Euler(new Vector3(moveabelOverlay.transform.rotation.eulerAngles.x, moveabelOverlay.transform.rotation.eulerAngles.y, 0));

        if (moveabelOverlay != null)
        {
            var lookAts = moveabelOverlay.GetComponentsInChildren<LookAt>();
            foreach (var lookAt in lookAts)
            {
                lookAt.enabled = isOn;
            }
        }
    }

    private void SetDragAndDrop(bool isOn)
    {
        var moveabelOverlay = FindObjectOfType<MoveabelOverlay>();
        if (moveabelOverlay != null)
            moveabelOverlay.GetComponentInChildren<DragAndDrop>().enabled = isOn;
    }
}