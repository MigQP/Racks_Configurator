using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Billboard : MonoBehaviour
{

    // ROTATE INDIVIDUAL RACK MEASURE OBJECT TO CAMERA ALWAYS
    void Update()
    {

        Vector3 targetPostition = new Vector3(Camera.main.transform.position.x,
                                               transform.position.y,
                                               Camera.main.transform.position.z);
        this.transform.LookAt(targetPostition);

    }
}