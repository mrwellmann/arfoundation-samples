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
        if (OverlayType == OverlayType.Background)
        {
            var overlays = FindObjectsOfType<ImageOverlay>(true);
            foreach (var overlay in overlays)
            {
                if (overlay.CurrentOverlayType == OverlayType.Background)
                {
                    overlay.gameObject.SetActive(isOn);
                }
            }
        }
        else
        {
            if (!isOn)
                return;

            var switchers = FindObjectsOfType<OverlaySwitcher>();
            foreach (var switcher in switchers)
            {
                SwitchOverlayType(switcher, OverlayType);
            }
        }
    }

    public void SwitchOverlayType(OverlaySwitcher switcher, OverlayType overlayType)
    {
        var overlays = FindObjectsOfType<ImageOverlay>(true);
        foreach (var overlay in overlays)
        {
            // skip background
            if (overlay.CurrentOverlayType == OverlayType.Background)
            {
                continue;
            }

            if (overlay.CurrentOverlayType == overlayType)
            {
                //only switch for this year other year will be done separately
                if (overlay.SetOverlayYear == switcher.ConnectedOverlayYear)
                {
                    overlay.gameObject.SetActive(switcher.toggle.isOn);
                }
            }
            else
            {
                overlay.gameObject.SetActive(false);
            }

            // set new overlay type
            switcher.CurrentOverlayType = overlayType;
        }
    }

    public void InitOverlaySettings()
    {
        var overlays = FindObjectsOfType<ImageOverlay>(true);
        var switchers = FindObjectsOfType<OverlaySwitcher>();

        foreach (var overlay in overlays)
        {
            if (overlay.CurrentOverlayType == OverlayType)
            {
                if (overlay.CurrentOverlayType == OverlayType.Background)
                {
                    overlay.gameObject.SetActive(GetComponent<Toggle>().isOn);
                    continue;
                }

                foreach (var switcher in switchers)
                {
                    if (overlay.SetOverlayYear == switcher.ConnectedOverlayYear)
                    {
                        bool activate = GetComponent<Toggle>().isOn && switcher.toggle.isOn;
                        overlay.gameObject.SetActive(activate);
                    }
                }
            }
        }
    }
}