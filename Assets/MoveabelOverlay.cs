using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveabelOverlay : MonoBehaviour
{
    public float SetPositionZPow2
    {
        set
        {
            //var distance = Mathf.Pow(value, 2);
            var distance = value;
            var pos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(pos.x, pos.y, -distance);
        }
    }

    public float SetScalePow2
    {
        set
        {
            //var scale = Mathf.Pow(value, 2);
            var scale = value;
            gameObject.transform.localScale = new Vector3(scale, 1, scale);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}