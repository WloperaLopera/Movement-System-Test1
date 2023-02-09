using System.Security.AccessControl;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAbleObject : MonoBehaviour
{
    public bool isPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       

        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
                                

            // if (Parent == Player) 
            // {
            //     nowPickable = true;
            // } else {
            //     nowPickable = false;
            // }
    
            // if (nowPickable == false) 
            // {
            //     UnityEngine.Debug.Log("nowPickable: false ");
            // } else {
            //     UnityEngine.Debug.Log(" nowPickable: true ");
            // }
        }
    }
}
