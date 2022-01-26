using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    public float movementSpeed = 0.2f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    private GameObject camObject;
 
    void Start()
    {
        cam = Camera.main;
        camObject = cam.gameObject;

        initialPosition = camObject.transform.position;
        initialRotation = camObject.transform.eulerAngles;

        xRotation = initialRotation.x;
        yRotation = initialRotation.y;
    }
 

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            // Rotation
            float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
    
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
    
            cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

            if(camObject != null)
            {
                // Position
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
            
                Vector3 movement = camObject.transform.forward * v * movementSpeed + camObject.transform.right * h * movementSpeed;
                movement.y = 0f;
                camObject.transform.position +=  movement;
            }
        }
    }

    public void RestartCameraPosition()
    {
        camObject.transform.position = initialPosition;
        camObject.transform.eulerAngles = initialRotation;
    }

    // Test EoM public events
    public void WhenExciteOMeterStarts()
    {
        Debug.LogWarning("START LOG SESSION: Actions from the end user");
    }

    public void WhenExciteOMeterStops()
    {
        Debug.LogWarning("STOP LOG SESSION: Actions from the end user");
    }
}

#if UNITY_EDITOR
//-------------------------------------------------------------------------
[UnityEditor.CustomEditor(typeof(CameraController))]
public class CameraControllerEditor : UnityEditor.Editor
{
    //-------------------------------------------------
    // Custom Inspector GUI allows us to click from within the UI
    //-------------------------------------------------
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraController myScript = (CameraController)target;

        if (GUILayout.Button("RESET CAMERA"))
        {
            myScript.RestartCameraPosition();
        }
    }
}
#endif