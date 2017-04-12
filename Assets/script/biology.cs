using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biology : MonoBehaviour
{
    Vector3 goPos;
    float speed;
    void Start()
    {
        goPos = transform.position;
        GetComponent<Animator>().SetBool("Grounded", true);
    }
    void Update()
    {
        moveto();
    }
    void moveto()
    {
        speed = Vector3.Distance(transform.position, goPos) * 2.5f;
        transform.position = Vector3.MoveTowards(transform.position, goPos, speed * Time.deltaTime);
        faceTarget(goPos, speed * 5);
        GetComponent<Animator>().SetFloat("MoveSpeed", speed);
    }
    public void setMoveTo(Vector3 direct)
    {
        goPos = transform.position + direct * 0.25f;
    }
    void faceTarget(Vector3 etarget, float espeed)
    {
        Vector3 targetDir = etarget - this.transform.position;
        float step = espeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, step, 0.0f);
        this.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
