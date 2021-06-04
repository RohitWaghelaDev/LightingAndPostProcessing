using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangerCameraRig : MonoBehaviour
{
    public Transform rigTop;
    public Transform rigbottom;
    public Transform cameraTransform;

    public float horizontalSpeed;
   

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 2.0f;

    // The time at which the animation started.
    private float startTime;

    [HideInInspector] public bool reachedRigTop;
    [HideInInspector] public bool reachedRigBotton;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
    }

    void Update()
    {
        cameraTransform.LookAt(transform.position);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            startTime = Time.time;
        }

        if (Input.GetKey(KeyCode.W) && !reachedRigTop )
        {
            //cameraTransform.position = Vector3.Slerp(cameraTransform.position, rigTop.position, Time.deltaTime* verticleSpeed );
            MoveUP();
        }
        else if (Input.GetKey(KeyCode.S) && !reachedRigBotton)
        {
            //cameraTransform.position = Vector3.Slerp(cameraTransform.position, rigbottom.position, Time.deltaTime* verticleSpeed );
            MoveDown();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up*Time.deltaTime* horizontalSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up * Time.deltaTime * (-horizontalSpeed));

        }

    }

    
    public void MoveUP()
    {

        // The center of the arc
        Vector3 center = (rigTop.position + rigbottom.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = rigTop.position - center;
        Vector3 setRelCenter = rigbottom.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        cameraTransform.position = Vector3.Slerp(setRelCenter, riseRelCenter, fracComplete);

        //cameraTransform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
       cameraTransform.position += center;

    }

    public void MoveDown()
    {

        // The center of the arc
        Vector3 center = (rigTop.position + rigbottom.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = rigTop.position - center;
        Vector3 setRelCenter = rigbottom.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        cameraTransform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);

        //cameraTransform.position = Vector3.Slerp(setRelCenter,riseRelCenter,fracComplete);
        cameraTransform.position += center;

    }


   
}
