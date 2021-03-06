using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement00 : MonoBehaviour
{
    /*CAMERA SYTEM (ROTATION, PAN OR ZOOM) BASED ON UI TOGGLES (WITH CLAMPS)*/


    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform targetObject;

    //--

    public float xSensitivity = 100.0f;
    public float ySensitivity = 100.0f;

    public float yMinLimit = -45.0f;
    public float yMaxLimit = 45.0f;

    public float xMinLimit = -360.0f;
    public float xMaxLimit = 360.0f;

    float yRot = 0.0f;
    float xRot = 0.0f;
    //--

    public Toggle rotateToggle;
    public Toggle panToggle;

    private float mouseSensitivity = .005f;

    private Vector3 previousPosition;

    private Vector3 dragOrigin;



    // ZOOM DE CAMARA

    private float zoom = 80f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        /*if (Input.GetMouseButtonUp(0))
        {
            transform.parent = Camera.main.transform;
        }*/

        if (rotateToggle.isOn)
        {

            rotateCamera();
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent = null;
                previousPosition = mainCam.ScreenToViewportPoint(Input.mousePosition);
            }




        }

        PanCamera();
        HandleZoom();

    }

    void rotateCamera()

    {
        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

            xRot = Mathf.Clamp(xRot, yMinLimit, yMaxLimit);
            yRot = Mathf.Clamp(yRot, xMinLimit, xMaxLimit);

            Camera.main.transform.localEulerAngles = new Vector3(-yRot, xRot, 0);
        }
    }

    void PanCamera()
    {
        if (panToggle.isOn)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 difference = Input.mousePosition - dragOrigin;
                mainCam.transform.Translate((difference.x * mouseSensitivity) * -1, (difference.y * mouseSensitivity) * -1, 0);
                dragOrigin = Input.mousePosition;

            }

        }

    }

    void HandleZoom()
    {
        float zoomChangeAmount = 40f;



        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            zoom -= zoomChangeAmount * Time.deltaTime;
            mainCam.transform.Translate((Vector3.forward * zoom) * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            zoom += zoomChangeAmount * Time.deltaTime;
            mainCam.transform.Translate((-Vector3.forward * zoom) * Time.deltaTime);
        }
    }

}

