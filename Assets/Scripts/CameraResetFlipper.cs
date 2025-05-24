 using UnityEngine;

public class CameraResetFlipper : MonoBehaviour
{
    [SerializeField] private Transform MainCameraParent;
    public Transform centerEyeAnchor;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // logging but not resetting
        // Reset camera position with left trigger
        // if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        // {
        //     transform.position = originalPosition;
        //     Debug.Log("Left trigger pressed: Camera reset to position: " + transform.position);
        // }

        // press left trigger to move camera to position (0, 0.675, 0)
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            Vector3 tempPosition = new Vector3(centerEyeAnchor.position.x, 0.0f, centerEyeAnchor.position.z);
            MainCameraParent.position = MainCameraParent.position - tempPosition;
            Debug.Log("left trigger pressed, new position: " + MainCameraParent.position);
        }

        // Flip camera 180 degrees with A button
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("A pressed: Camera flipped. Current rotation: " + transform.eulerAngles);
        }
    }
}
