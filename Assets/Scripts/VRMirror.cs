using UnityEngine;
using UnityEngine.UIElements;

public class VRMirror : MonoBehaviour
{
    public Transform centerEyeAnchor;
    public Transform mirrorHead;
    public Transform mirror;

    private Vector3 ogPosition = new Vector3(0f, .675f, 0f);
    private bool isMirroring = false;   // else matching
    public bool trackPosition = true;
    public bool trackRotation = true;

    void Update()
    {     
        // Toggle mirroring or matching with B button
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            isMirroring = !isMirroring;
        }

        if (isMirroring)    // mirror movement
        {

            Vector3 toMirror = centerEyeAnchor.position - mirror.position;
            Vector3 mirroredPosition = mirror.position - toMirror;

            if (trackPosition)
            {

                // mirrorHead.position = mirroredPosition;
            }

            if (trackRotation)
            {
                Vector3 lookDirection = mirror.position - mirroredPosition;
                mirrorHead.rotation = Quaternion.LookRotation(lookDirection);
                // mirrorHead.rotation = Quaternion.LookRotation(centerEyeAnchor.forward * -1, Vector3.up);
                mirrorHead.Rotate(0f, 270f, 0f);
            }
            
        }
        
        else    // match movement
        {
            if (trackPosition)
            {
                Vector3 matchedPosition = centerEyeAnchor.position - ogPosition;
                mirrorHead.position = mirrorHead.position + matchedPosition;
            }

            if (trackRotation)
            {
                mirrorHead.rotation = centerEyeAnchor.rotation;
            }
        }
    }
}
