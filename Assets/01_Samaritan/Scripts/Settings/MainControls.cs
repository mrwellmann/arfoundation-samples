using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MainControls : MonoBehaviour
{
    [SerializeField]
    private Toggle _planes;
    [SerializeField]
    private Toggle _featurePoints;

    public void Init()
    {
        _planes.onValueChanged.AddListener(EnablePlanes);
        _featurePoints.onValueChanged.AddListener(EnableFeaturePoints);

        EnablePlanes(_planes.isOn);
        EnableFeaturePoints(_featurePoints.isOn);
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