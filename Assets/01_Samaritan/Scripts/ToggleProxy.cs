using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleProxy : MonoBehaviour
{
    private enum ToggleType
    {
        Fade,
        Fill
    }

    [SerializeField]
    private ToggleType _toggleTypeSetting;
    private Toggle _toggle;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        var imageOverlays = FindObjectsOfType(typeof(ImageOverlay));
        foreach (var overlay in imageOverlays)
        {
            {
                var imageOverlay = overlay as ImageOverlay;
                if (imageOverlay != null)
                {
                    switch (_toggleTypeSetting)
                    {
                        case ToggleType.Fade:
                            imageOverlay.UseFade(_toggle.isOn);
                            break;
                        case ToggleType.Fill:
                            imageOverlay.UseFill(_toggle.isOn);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}