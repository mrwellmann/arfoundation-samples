using TMPro;
using UnityEngine;

public class DistanceToText : MonoBehaviour
{
    [SerializeField]
    private Transform user = null;
    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private TextMeshProUGUI output = null;

    void Update()
    {
        if (target == null || target.gameObject.activeSelf == false)
        {
            output.text = "NA";
        }
        else
        {
            var distance = Vector3.Distance(user.position, target.transform.position);
            output.text = distance.ToString("F1") + " m";
        }

    }
}
