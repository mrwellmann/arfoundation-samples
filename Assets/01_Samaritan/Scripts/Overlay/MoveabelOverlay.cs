using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleLogger = UnityEngine.XR.ARFoundation.Samples.Logger;

public class MoveabelOverlay : MonoBehaviour
{
    public static event Action<MoveabelOverlay> MoveabelOverlayCreated;

    private void Start()
    {
        var overlayDebugToggless = FindObjectsOfType<OverlayToggle>(true);
        foreach (var toggles in overlayDebugToggless)
        {
            toggles.InitOverlaySettings();
        }

        MoveabelOverlayCreated?.Invoke(this);
        SampleLogger.Log($"MoveabelOverlay created at Position {transform.position}, Rotation {transform.rotation.eulerAngles}, Scale {transform.localScale}.");
    }

    public float ChageDistanceToCamera
    {
        set
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            transform.Translate(cameraForward * value, Space.World);

            //var distance = Mathf.Pow(value, 2);
            //var distance = value;
            //var pos = gameObject.transform.position;
            //gameObject.transform.position = new Vector3(pos.x, pos.y, -distance);
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
            var newValue = gameObject.transform.localScale.x + value;
            gameObject.transform.localScale = new Vector3(newValue, newValue, newValue);
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
}