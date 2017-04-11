using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biology : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setMoveTo(Vector3 direct)
    {
        transform.position += direct * 0.01f;
    }
    void moveto()
    {

    }

}
