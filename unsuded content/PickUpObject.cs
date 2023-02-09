using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public bool nowPickable;

   
    void Update()
    {
         
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                 UnityEngine.Debug.Log("ObjectToPickUp:" + ObjectToPickUp);
                 UnityEngine.Debug.Log("PickedObject:" + PickedObject);      
                 if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickAbleObject>().isPickable == true && PickedObject == null)
                 {
                    PickedObject = ObjectToPickUp;
                    PickedObject.GetComponent<PickAbleObject>().isPickable = false;
                    PickedObject.transform.SetParent(interactionZone);
                    PickedObject.transform.position = interactionZone.position;
                    PickedObject.GetComponent<Rigidbody>().useGravity = false;
                    PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                    nowPickable = true;

                 } else {
                    PickedObject.GetComponent<PickAbleObject>().isPickable = true;
                    PickedObject.transform.SetParent(null);
                    PickedObject.GetComponent<Rigidbody>().useGravity = true;
                    PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                    PickedObject = null;
                 }
             }
        }       

    }  
}
