using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverlayPositioning : MonoBehaviour
{
    [SerializeField]
    private SliderHandleClick distanceSlider;
    [SerializeField]
    private TextMeshProUGUI distanceSliderTextValue;
    [SerializeField]
    private SliderHandleClick scaleSlider;
    [SerializeField]
    private TextMeshProUGUI scaleSliderTextValue;
    [SerializeField]
    private Toggle lookAt;
    [SerializeField]
    private Toggle dragAndDrop;
    [SerializeField]
    private Button centerToView;
    [SerializeField]
    private Button pitchPlus;
    [SerializeField]
    private Button pitchMinus;
    [SerializeField]
    private Button yawPlus;
    [SerializeField]
    private Button yawMinus;
    [SerializeField]
    private Button rolePlus;
    [SerializeField]
    private Button roleMinus;

    private MoveabelOverlay currentOverlay = null;

    private void Start()
    {
        MoveabelOverlay.MoveabelOverlayCreated += (moveabelOverlay) => { this.currentOverlay = moveabelOverlay; };

        distanceSlider.WhileSliderHandleDown += ChangeDistanceInMeter;
        scaleSlider.WhileSliderHandleDown += ChangeScale;
        centerToView.onClick.AddListener(CenterToView);
        lookAt.onValueChanged.AddListener(SetLookAt);
        dragAndDrop.onValueChanged.AddListener(SetDragAndDrop);

        pitchPlus.onClick.AddListener(SetPitchPlus);
        pitchMinus.onClick.AddListener(SetPitchMinus);
        yawPlus.onClick.AddListener(SetYawPlus);
        yawMinus.onClick.AddListener(SetYawMinus);
        rolePlus.onClick.AddListener(SetRolePlus);
        roleMinus.onClick.AddListener(SetRoleMinus);

        SetLookAt(lookAt.isOn);
        SetDragAndDrop(dragAndDrop.isOn);

        if (currentOverlay != null)
        {
            UpdateDistanceText(currentOverlay);
            UpdateSacaleText(currentOverlay);
        }
    }

    private void SetPitchPlus()
    {
        if (currentOverlay != null)
            currentOverlay.Pitch(1);
    }

    private void SetPitchMinus()
    {
        if (currentOverlay != null)
            currentOverlay.Pitch(-1);
    }

    private void SetYawPlus()
    {
        if (currentOverlay != null)
            currentOverlay.Yaw(1);
    }

    private void SetYawMinus()
    {
        if (currentOverlay != null)
            currentOverlay.Yaw(-1);
    }

    private void SetRolePlus()
    {
        if (currentOverlay != null)
            currentOverlay.Role(1);
    }

    private void SetRoleMinus()
    {
        if (currentOverlay != null)
            currentOverlay.Role(-1);
    }

    private void CenterToView()
    {
        if (currentOverlay != null)
            currentOverlay.MoveToPositionKeepDisctanceToCamera();
    }

    private void ChangeDistanceInMeter(float delta)
    {
        if (currentOverlay != null)
        {
            currentOverlay.ChageDistanceToCamera = delta;
            UpdateDistanceText(currentOverlay);
        }
    }

    private void ChangeScale(float delta)
    {
        if (currentOverlay != null)
        {
            currentOverlay.ChangeScale = delta;
            UpdateSacaleText(currentOverlay);
        }
    }

    private void UpdateDistanceText(MoveabelOverlay moveabelOverlay)
    {
        distanceSliderTextValue.text = Vector3.Distance(moveabelOverlay.transform.position, Camera.main.transform.position).ToString("0.0");
    }

    private void UpdateSacaleText(MoveabelOverlay moveabelOverlay)
    {
        scaleSliderTextValue.text = moveabelOverlay.transform.localScale.x.ToString("0.0");
    }

    private void SetLookAt(bool isOn)
    {
        if (currentOverlay != null)
        {
            //currentOverlay.transform.rotation.SetEulerAngles(currentOverlay.transform.rotation.eulerAngles.x, currentOverlay.transform.rotation.eulerAngles.y, 0);
            currentOverlay.transform.rotation = Quaternion.Euler(new Vector3(currentOverlay.transform.rotation.eulerAngles.x, currentOverlay.transform.rotation.eulerAngles.y, 0));

            var lookAts = currentOverlay.GetComponentsInChildren<LookAt>();
            foreach (var lookAt in lookAts)
            {
                lookAt.enabled = isOn;
            }
        }
    }

    private void SetDragAndDrop(bool isOn)
    {
        if (currentOverlay != null)
            currentOverlay.GetComponentInChildren<DragAndDrop>().enabled = isOn;
    }
}