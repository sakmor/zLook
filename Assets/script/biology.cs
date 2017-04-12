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
        float scale = 2.5f;
        speed = Vector3.Distance(transform.position, goPos);
        transform.position = Vector3.MoveTowards(transform.position, goPos, scale * speed * Time.deltaTime);
        faceTarget(goPos, speed * 5);
        GetComponent<Animator>().SetFloat("MoveSpeed", speed);
    }
    public void setMoveTo(Vector3 direct)
    {
        float scale = 0.5f;
        goPos = transform.position + direct * scale;
    }
    void faceTarget(Vector3 etarget, float espeed)
    {
        Vector3 targetDir = etarget - this.transform.position;
        float step = espeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, step, 0.0f);
        this.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
