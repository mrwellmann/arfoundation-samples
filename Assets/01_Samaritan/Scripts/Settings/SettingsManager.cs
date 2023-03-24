using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private MainControls mainControls;
    [SerializeField]
    private OverlaySelection overlaySelection;
    [SerializeField]
    private OverlayPositioning overlayPositioning;

    private void Start()
    {
        mainControls.gameObject.SetActive(true);
        overlaySelection.gameObject.SetActive(false);
        overlayPositioning.gameObject.SetActive(false);

        mainControls.Init();
        overlaySelection.Init();
        overlayPositioning.Init();
    }
}