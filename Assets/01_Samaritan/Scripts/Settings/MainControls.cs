using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class MainControls : MonoBehaviour
{
    [SerializeField]
    private Toggle _planes;
    [SerializeField]
    private Toggle _featurePoints;
    [SerializeField]
    private Toggle _anchorPlacing;

    public void Init()
    {
        _planes.onValueChanged.AddListener(EnablePlanes);
        _featurePoints.onValueChanged.AddListener(EnableFeaturePoints);
        _anchorPlacing.onValueChanged.AddListener(EnableAnchorPlacing);

        EnablePlanes(_planes.isOn);
        EnableFeaturePoints(_featurePoints.isOn);
        EnableAnchorPlacing(_anchorPlacing.isOn);
    }

    private void EnableAnchorPlacing(bool isOn)
    {
        CustomAnchorCreator customAnchorCreator = XROrigin.FindObjectOfType<CustomAnchorCreator>();
        customAnchorCreator.enabled = isOn;
    }

    private void EnableFeaturePoints(bool isOn)
    {
        ARPointCloudManager aRPointCloudManager = XROrigin.FindObjectOfType<ARPointCloudManager>();

        aRPointCloudManager.SetTrackablesActive(isOn);
        aRPointCloudManager.enabled = isOn;
    }

    private void EnablePlanes(bool isOn)
    {
        ARPlaneManager aRPlaneManager = XROrigin.FindObjectOfType<ARPlaneManager>();
        aRPlaneManager.SetTrackablesActive(isOn);
        aRPlaneManager.enabled = isOn;
    }
}