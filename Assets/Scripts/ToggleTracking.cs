using UnityEngine;

public class ToggleTracking : MonoBehaviour
{
    public VRMirror vrMirror;

    // public Transform mirrorHead;
    // public Transform cameraRig; // This is usually the CenterEyeAnchor
    // private Vector3 positionOffset;
    // private Quaternion rotationOffset;
    // private bool positionTrackingDisabled = false;
    // private bool rotationTrackingDisabled = false;

    void Update()
    {
        // Toggle rotation tracking with Y button (LEFT controller)
        if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            vrMirror.trackRotation = !vrMirror.trackRotation;
            // rotationTrackingDisabled = !rotationTrackingDisabled;
            // if (rotationTrackingDisabled)
            // {
            //     rotationOffset = Quaternion.Inverse(cameraRig.rotation) * transform.rotation;
            //     Debug.Log("Rotation tracking disabled");
            // }
            // else
            // {
            //     Debug.Log("Rotation tracking enabled");
            // }

            Debug.Log("Y pressed");
        }

        // Toggle position tracking with X button (LEFT controller)
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            vrMirror.trackPosition = !vrMirror.trackPosition;
            // positionTrackingDisabled = !positionTrackingDisabled;
            // if (positionTrackingDisabled)
            // {
            //     positionOffset = transform.position - cameraRig.position;
            //     Debug.Log("Position tracking disabled");
            // }
            // else
            // {
            //     Debug.Log("Position tracking enabled");
            // }

            Debug.Log("X pressed");
        }

        // Apply offsets if tracking is disabled
        // if (rotationTrackingDisabled)
        // {
        //     transform.rotation = cameraRig.rotation * rotationOffset;
        // }

        // if (positionTrackingDisabled)
        // {
        //     transform.position = cameraRig.position + positionOffset;
        // }
    }
}
