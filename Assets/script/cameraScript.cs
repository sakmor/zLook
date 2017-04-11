using UnityEngine;
using UnityEngine.EventSystems;

//我是從下面這個檔案改得
//http://wiki.unity3d.com/index.php?title=MouseOrbitImproved

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class cameraScript : MonoBehaviour
{
    float distance = 2f;
    float xSpeed = 5.0f;
    float ySpeed = 5.0f;
    public Vector3 offset;
    float yMinLimit = -20f;
    float yMaxLimit = 80f;
    float distanceMin = 1f;
    float distanceMax = 3f;
    private main main;
    float x = 0.0f, startX = 0.0f, finalX = 0.0f, y = 0.0f;
    Vector3 cam2Target;
    Transform target;
    public Transform lookTarget;
    // Use this for initialization
    void Start()
    {
        setAsEditor();
    }

    void LateUpdate()
    {
        mouseOrbitWhenMouseInput();
        cameraFollow();
    }
    void mouseOrbit()
    {
        x += Input.GetAxis("Mouse X") * xSpeed;
        y -= Input.GetAxis("Mouse Y") * ySpeed;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + offset;
        transform.rotation = rotation;
        transform.position = position + lookTarget.position;

        setCame2Target();
    }
    void mouseOrbitWhenMouseInput()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.currentSelectedGameObject)
        {
            mouseOrbit();
        }
    }
    void cameraFollow()
    {
        transform.position = target.position + cam2Target;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    public void setTarget(Transform n)
    {
        target = n;
        lookTarget = n;
    }
    public void setOffset(Vector3 n)
    {
        offset = n;
        mouseOrbit();
    }
    void setCame2Target()
    {
        if (target)
            cam2Target = transform.position - target.position;
    }
    void setAsEditor()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
}