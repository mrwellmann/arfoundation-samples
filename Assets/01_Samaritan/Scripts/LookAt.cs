using UnityEngine;

public class LookAt : MonoBehaviour
{
    public enum Constraints
    {
        Free = 0,
        LocalX = 1,
        LocalY = 2,
        LocalZ = 3,
    }

    private static Vector3[] ConstraintsScaleVectors = { Vector3.one, /* X/Right */ new Vector3(0, 1, 1), /* Y/Up */ new Vector3(1, 0, 1), /* Z/Front */ new Vector3(1, 1, 0) };

    [Tooltip("The constraint applied to the look-at rotation. Use a value other than 'Free' to limit the rotation to the specified axis.")]
    [SerializeField()]
    private Constraints _constraint = Constraints.Free;
    [SerializeField()]
    private bool _invert = false;

    [Tooltip("Amount of dampening applied when interpolating the current and the look-at rotation.")]
    [Range(0.0f, 1.0f)]
    [SerializeField()]
    private float _dampening = 0.75f;

    [Tooltip("(Optional) The target object the look at behaviour is looking at. If not set the Camera.main.transform transform is used.")]
    [SerializeField()]
    private Transform _target = null;

    protected Transform Target
    {
        get
        {
            if (_target == null)
                _target = Camera.main.transform;
            return _target;
        }
    }

    public Constraints Constraint
    {
        get { return _constraint; }
        set { _constraint = value; }
    }

    public float Dampening
    {
        get { return _dampening; }
        set { _dampening = value; }
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.Target != null)
        {
            Vector3 lookDir = this.Target.position - this.transform.position;
            // transform to local space to allow limiting axis according to the objects local space
            if (this.transform.parent != null)
                lookDir = this.transform.parent.InverseTransformDirection(lookDir);

            if (_constraint != Constraints.Free)
                lookDir = Vector3.Scale(lookDir, LookAt.ConstraintsScaleVectors[(int)_constraint]);

            if (_invert)
                lookDir = -lookDir;
            Quaternion lookRot = Quaternion.LookRotation(lookDir, Vector3.up);
            this.transform.localRotation = Quaternion.Slerp(lookRot, this.transform.localRotation, _dampening);
        }
    }

    // helper method to allow setting it using the UnityEngine.Events.UnityEvent classes
    public void SetConstraints(int constraintValue)
    {
        if (constraintValue >= 0 && constraintValue <= 3)
            _constraint = (Constraints)constraintValue;
    }
}