using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_Ctrl : MonoBehaviour
{
    Vector2 rightClickPos;
    Vector3 cameraCurrentPos;
    Vector2 scroll;
    Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            rightClickPos = Mouse.current.position.ReadValue();
            cameraCurrentPos = camera.transform.position;
            Debug.LogError("righClickPos" + rightClickPos);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 curMousePos = Mouse.current.position.ReadValue();
            Debug.Log("curMousePos : " + curMousePos);
            //Vector3 cameraMovePos = new Vector3((rightClickPos - curMousePos).x * 0.1f, camera.gameObject.transform.position.y, (rightClickPos - curMousePos).y * 0.1f);
            Vector3 cameraMovePos = new Vector3(cameraCurrentPos.x + (rightClickPos.x - curMousePos.x) * 0.1f, cameraCurrentPos.y + (rightClickPos.y - curMousePos.y) * 0.1f, cameraCurrentPos.z);
            camera.transform.position = cameraMovePos;
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {

        }

        scroll = Mouse.current.scroll.ReadValue();


        if (scroll.y != 0)
        {
            Debug.Log("¸¶¿ì½º ÈÙ ¾÷" + scroll);
            Vector3 currentPos = camera.transform.position;
            camera.transform.position = new Vector3(currentPos.x, currentPos.y, currentPos.z - scroll.y);
        }
    }
}
