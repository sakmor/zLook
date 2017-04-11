using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZLookScript : MonoBehaviour
{
    public Transform lookTarget, followTarget;
    Vector3 cam2Target;
    bool isZLook;

    // Use this for initialization
    void Start()
    {
        isZLook = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isZLook)
        {
            // transform.LookAt(lookTarget);
            // cameraFollow();
        }
    }
    void cameraFollow()
    {
        transform.position = followTarget.position + cam2Target;
    }
    void setCame2target()
    {
        cam2Target = transform.position - followTarget.position;
    }
    void setLookTarget(Transform n)
    {
        lookTarget = n.Find("N1");  //todo:當目標沒有N1點的時候會當機
    }
    public void setFollowTarget(Transform n)
    {
        followTarget = n;
    }

    public void setZLookOff()
    {
        isZLook = false;
    }
    public void setZLookOn(Transform t)
    {
        if (!isZLook)
        {
            isZLook = true;
            setLookTarget(t);
            transform.position = followTarget.position;
            // setCame2target();
        }
    }
}
