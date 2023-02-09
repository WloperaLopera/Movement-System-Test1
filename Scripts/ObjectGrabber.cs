using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
private GrabbableObject grabbableObject;
void Update()
{
    if (Input.GetKeyDown(KeyCode.E))
    {
        // Check if there is a GrabbableObject within the trigger area
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        float distance = Mathf.Infinity;
        GrabbableObject closestGrabbableObject = null;

        foreach (Collider collider in colliders)
        {
            grabbableObject = collider.GetComponent<GrabbableObject>();
            if (grabbableObject && grabbableObject.isGrabbable)
            {
                float currentDistance = Vector3.Distance(transform.position, grabbableObject.transform.position);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    closestGrabbableObject = grabbableObject;
                }
            }
        }

        if (closestGrabbableObject)
        {
            if (closestGrabbableObject.transform.parent == transform)
            {
                // Drop the object
                closestGrabbableObject.transform.parent = null;
                closestGrabbableObject.GetComponent<Rigidbody>().useGravity = true;
            }
            else
            {
                // Grab the object
                closestGrabbableObject.transform.parent = transform;
                closestGrabbableObject.transform.position = transform.position;
                closestGrabbableObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }
}
}