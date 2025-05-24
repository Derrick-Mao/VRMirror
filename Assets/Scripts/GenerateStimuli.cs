using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{
    public GameObject redSphere;
    public GameObject smallBlueSphere;
    public GameObject largeBlueSphere;
    public Transform centerEyeAnchor;

    private bool isActive = false;
    private bool spheresVisible = true;
    private float timer = 0f;
    private bool delaying = false;

    void Start()
    {
        // Assign unique materials to each sphere to prevent shared material issues
        Renderer redRend = redSphere.GetComponent<Renderer>();
        redRend.material = new Material(redRend.material);
        redRend.material.color = Color.red;

        Renderer smallBlueRend = smallBlueSphere.GetComponent<Renderer>();
        smallBlueRend.material = new Material(smallBlueRend.material);
        smallBlueRend.material.color = Color.blue;

        Renderer largeBlueRend = largeBlueSphere.GetComponent<Renderer>();
        largeBlueRend.material = new Material(largeBlueRend.material);
        largeBlueRend.material.color = Color.blue;
    }

    void Update()
    {
        // Toggle script activation with S button
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            isActive = !isActive;
        }

        // Toggle spheres visibility with right trigger
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (spheresVisible)
            {
                redSphere.SetActive(false);
                delaying = true;
                timer = 0f;
            }
            else
            {
                redSphere.SetActive(true);
                delaying = true;
                timer = 0f;
            }
            spheresVisible = !spheresVisible;
        }

        // Handle 2-second delay for blue spheres
        if (delaying)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                smallBlueSphere.SetActive(spheresVisible);
                largeBlueSphere.SetActive(spheresVisible);
                delaying = false;
            }
        }

        // Adjust blue spheres sizes if active
        if (isActive)
        {
            AdjustSphereSizes();
        }
    }

    void AdjustSphereSizes()
    {
        float redDistance = Vector3.Distance(centerEyeAnchor.position, redSphere.transform.position);
        float redRadius = redSphere.transform.localScale.x / 2f;

        // Adjust small blue sphere
        float smallBlueDistance = Vector3.Distance(centerEyeAnchor.position, smallBlueSphere.transform.position);
        float smallBlueTargetRadius = (redRadius * smallBlueDistance) / redDistance;
        smallBlueSphere.transform.localScale = Vector3.one * (smallBlueTargetRadius * 2f);

        // Adjust large blue sphere
        float largeBlueDistance = Vector3.Distance(centerEyeAnchor.position, largeBlueSphere.transform.position);
        float largeBlueTargetRadius = (redRadius * largeBlueDistance) / redDistance;
        largeBlueSphere.transform.localScale = Vector3.one * (largeBlueTargetRadius * 2f);
    }
}
