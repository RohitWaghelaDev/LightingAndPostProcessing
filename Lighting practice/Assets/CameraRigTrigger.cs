using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigTrigger : MonoBehaviour
{


    private HangerCameraRig hangerCameraRig;

    private void Start()
    {
        hangerCameraRig = GetComponentInParent<HangerCameraRig>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RigTop"))
        {
            hangerCameraRig.reachedRigTop = true;
        }

        if (other.gameObject.CompareTag("RigBottom"))
        {
            hangerCameraRig.reachedRigBotton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RigTop"))
        {
            hangerCameraRig.reachedRigTop = false;
        }

        if (other.gameObject.CompareTag("RigBottom"))
        {
            hangerCameraRig.reachedRigBotton = false;
        }
    }
}
