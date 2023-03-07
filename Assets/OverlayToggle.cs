using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class OverlayToggle : MonoBehaviour
{
    public OverlayType OverlayType;

    private void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (!isOn)
            return;

        var switchers = FindObjectsOfType<OverlaySwitcher>();
        foreach (var switcher in switchers)
        {
            switcher.DeactivateCurentOverlays();
            switcher.ConnectedOverlayType = OverlayType;
        }
    }
}