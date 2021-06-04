using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraRig : MonoBehaviour
{
    public Transform tankTransform;

    public float rig_xPositonIncrement;
    public float rig_YPositonIncrement;

    private CinemachineFreeLook freeLookCamera;


    // Start is called before the first frame update
    void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W) )
        {
            freeLookCamera.m_YAxis.Value += rig_YPositonIncrement;
        }
        else if (Input.GetKey(KeyCode.S) )
        {
            freeLookCamera.m_YAxis.Value -= rig_YPositonIncrement;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //freeLookCamera.m_XAxis.Value -= rig_xPositonIncrement;
            tankTransform.Rotate(transform.up*Time.deltaTime*(-30));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //freeLookCamera.m_XAxis.Value += rig_xPositonIncrement;
            tankTransform.Rotate(transform.up * Time.deltaTime * 30);
        }
    }
}
