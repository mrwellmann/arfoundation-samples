using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveabelOverlay : MonoBehaviour
{
    public float ChageDistanceToCamera
    {
        set
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            transform.Translate(cameraForward * value);

            //var distance = Mathf.Pow(value, 2);
            //var distance = value;
            //var pos = gameObject.transform.position;
            //gameObject.transform.position = new Vector3(pos.x, pos.y, -distance);
        }
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