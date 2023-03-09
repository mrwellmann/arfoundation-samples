using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveabelOverlay : MonoBehaviour
{
    private void Start()
    {
        var overlayDebugToggless = FindObjectsOfType<OverlayToggle>(true);
        foreach (var toggles in overlayDebugToggless)
        {
            toggles.InitOverlaySettings();
        }
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
}