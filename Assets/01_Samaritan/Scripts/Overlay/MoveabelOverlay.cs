using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleLogger = UnityEngine.XR.ARFoundation.Samples.Logger;

public class MoveabelOverlay : MonoBehaviour
{
    public static event Action<MoveabelOverlay> MoveabelOverlayCreated;

    [SerializeField]
    private GameObject Bachground1;
    [SerializeField]
    private GameObject Bachground2;

    private float transparency = 80;

    private void Start()
    {
        var overlayDebugToggless = FindObjectsOfType<OverlayToggle>(true);
        foreach (var toggle in overlayDebugToggless)
        {
            toggle.InitOverlaySettings();
        }

        MoveabelOverlayCreated?.Invoke(this);
        SampleLogger.Log($"MoveabelOverlay created at Position {transform.position}, Rotation {transform.rotation.eulerAngles}, Scale {transform.localScale}.");
    }

    public float ChageDistanceToCamera
    {
        set
        {
            Vector3 cameraForward = Camera.main.transform.forward;

            //transform.Translate(cameraForward * value, Space.World);
            var distance = Vector3.Distance(Camera.main.transform.position, this.transform.position);
            var parentDistance = Vector3.Distance(Camera.main.transform.position, this.transform.parent.transform.position);

            var changedDistance = (distance - parentDistance);

            //var change = Mathf.Pow(changedDistance, 2) - 1;
            var change = changedDistance * value + value;

            // only go as far back as anchor is and don't go negative
            if (distance >= parentDistance || change > 0)
            {
                transform.Translate(cameraForward * change, Space.World);
            }
        }
    }

    public void MoveToPositionKeepDisctanceToCamera()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        transform.position = Camera.main.transform.position;

        float newDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        transform.position += (distance - newDistance) * Camera.main.transform.forward;
    }

    public float ChangeScale
    {
        set
        {
            if (gameObject.transform.localScale.x > 0.01f)
            {
                var newValue = gameObject.transform.localScale.x + (value * gameObject.transform.localScale.x);
                gameObject.transform.localScale = new Vector3(newValue, newValue, newValue);
            }
        }
    }

    public float Transparency
    {
        get
        {
            return transparency;
        }
        set
        {
            transparency = value;
            var overlays = GetComponentsInChildren<ImageOverlay>(true);
            foreach (var overlay in overlays)
            {
                overlay.Transparency = transparency;
            }
        }
    }

    public void Pitch(float value)
    {
        gameObject.transform.Rotate(new Vector3(value, 0, 0), Space.Self);
    }

    public void Yaw(float value)
    {
        gameObject.transform.Rotate(new Vector3(0, value, 0), Space.Self);
    }

    public void Role(float value)
    {
        gameObject.transform.Rotate(new Vector3(0, 0, value), Space.Self);
    }

    public void SetBackground1(bool isOn)
    {
        Bachground1.SetActive(true);
    }

    public void SetBackground2(bool isOn)
    {
        Bachground2.SetActive(true);
    }
}