﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    visualJoyStick visualJoyStick;
    cameraScript cam;
    cameraZLookScript camZLook;
    biology player;
    GameObject[] targets;
    GameObject target;
    bool isZLook;

    // Use this for initialization
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("blue");
        cam = GameObject.Find("Main Camera").GetComponent<cameraScript>();
        camZLook = GameObject.Find("cameraZLook").GetComponent<cameraZLookScript>();
        visualJoyStick = GameObject.Find("visualJoyStick").GetComponent<visualJoyStick>();
        player = GameObject.Find("player").GetComponent<biology>();
        cam.setTarget(player.transform);
        camZLook.setFollowTarget(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        controlPlayer();
        searchClosetTarget();

    }
    void searchClosetTarget()
    {
        float dist = Mathf.Infinity;
        GameObject tempTarget = null;
        foreach (var t in targets)
        {
            float temp = Vector3.Distance(t.transform.position, player.transform.position);
            if (temp < dist)
            {
                tempTarget = t;
                dist = temp;
            }
        }
        //todo: 暫時標示用
        GameObject.Find("Cube").transform.position = tempTarget.transform.position + Vector3.up * 1.2f;
        target = tempTarget;
    }

    void controlPlayer()
    {

        Vector3 newDirect = Vector3.zero;

        if (Input.GetKey("left shift"))
        {
            useZLookCam();
            camZLook.setZLookOn(target);
            isZLook = true;
        }
        if (Input.GetKeyUp("left shift"))
        {
            useNormalCam();
            isZLook = false;
        }

        if (visualJoyStick.touch)
        {
            newDirect = transformJoyStickSpace(visualJoyStick.joyStickVec, cam.transform);
            if (isZLook)
                newDirect = transformJoyStickSpace(visualJoyStick.joyStickVec, camZLook.transform);
            player.setMoveTo(newDirect);
        }

    }
    void useZLookCam()
    {
        cam.GetComponent<Camera>().enabled = false;
        camZLook.GetComponent<Camera>().enabled = true;
    }
    void useNormalCam()
    {
        cam.setPos(camZLook.transform);
        cam.GetComponent<Camera>().enabled = true;
        camZLook.GetComponent<Camera>().enabled = false;
    }

    //將 參數一 的2D向量，改為 參數二 Transform為座標空間
    Vector3 transformJoyStickSpace(Vector2 vec, Transform t)
    {
        //取得Transform t的朝前、朝右向量
        Vector3 forward = new Vector3(t.transform.forward.x, 0, t.transform.forward.z);
        Vector3 right = new Vector3(t.transform.right.x, 0, t.transform.right.z);

        //將左右向量標準化（變成最短）
        forward = Vector3.Normalize(forward);
        right = Vector3.Normalize(right);

        //將標準化左右向量加上搖桿的放大量
        right *= vec.x;
        forward *= vec.y;

        return forward + right;
    }

}
