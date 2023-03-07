using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class OverlaySwitcher : MonoBehaviour
{
    public OverlayType ConnectedOverlayType;
    public OverlayYear ConnectedOverlayYear;
    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (ConnectedOverlayYear == OverlayYear.None)
            throw new Exception("OverlayType is not set in OverlaySwitcher.cs");

        var overlays = FindObjectsOfType<ImageOverlay>(true);
        foreach (var overlay in overlays)
        {
            if (overlay.CurrentOverlayYear == ConnectedOverlayYear &&
                overlay.CurrentOverlayType == ConnectedOverlayType)
            {
                overlay.gameObject.SetActive(isOn);
            }
        }
    }

    internal void DeactivateCurentOverlays()
    {
        var overlays = FindObjectsOfType<ImageOverlay>(true);
        foreach (var overlay in overlays)
        {
            if (overlay.CurrentOverlayYear == ConnectedOverlayYear)
            {
                overlay.gameObject.SetActive(false);
            }
        }
    }
}