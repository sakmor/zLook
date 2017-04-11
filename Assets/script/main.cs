using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    visualJoyStick visualJoyStick;
    cameraScript cam;
    biology player;

    // Use this for initialization
    void Start()
    {

        cam = GameObject.Find("Main Camera").GetComponent<cameraScript>();
        visualJoyStick = GameObject.Find("visualJoyStick").GetComponent<visualJoyStick>();
        player = GameObject.Find("player").GetComponent<biology>();
        cam.setTarget(player.transform);
    }

    // Update is called once per frame
    void Update()
    {

        controlPlayer();
    }

    void controlPlayer()
    {
        if (visualJoyStick.touch)
        {
            Vector3 newDirect = Vector3.zero;
            newDirect = transformJoyStickSpace(visualJoyStick.joyStickVec, cam.transform);
            player.setMoveTo(newDirect);
        }
    }
    Vector3 transformJoyStickSpace(Vector2 vec, Transform t)
    {
        //取得攝影機朝前、朝右向量
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
    public Transform getPlayerTransform()
    {
        return player.transform;
    }
}
