using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biology : MonoBehaviour
{
    Vector3 goPos;
    void Start()
    {
        GetComponent<Animator>().SetBool("Grounded", true);
    }
    void Update()
    {

    }
    public void setMoveTo(Vector3 direct)
    {
        goPos = transform.position + direct;
        float speed = Vector3.Distance(Vector3.zero, direct);
        transform.position = Vector3.MoveTowards(transform.position, goPos, 2 * speed * Time.deltaTime);
        faceTarget(goPos, speed * 5);
        GetComponent<Animator>().SetFloat("MoveSpeed", speed);
    }
    void faceTarget(Vector3 etarget, float espeed)
    {
        Vector3 targetDir = etarget - this.transform.position;
        float step = espeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, step, 0.0f);
        this.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
