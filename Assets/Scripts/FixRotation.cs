using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixRotation : MonoBehaviour
{
    /*THIS SCRIPT ENSURES THAT THE INCOMING RACK ROTATION IS CONSISTENT WITH THE REST*/


    public GameObject originalObj;
    private Transform detectorT;


    // Start is called before the first frame update
    void Start()
    {
        detectorT = GetComponent<Transform>();
        
        
        if (originalObj.transform.rotation.y != 0)
        {
            detectorT.rotation = Quaternion.Euler(transform.rotation.x, originalObj.transform.rotation.y, transform.rotation.z);
            detectorT.position = new Vector3(detectorT.position.x + -0.01774175f, detectorT.position.y, detectorT.position.z);
        }
        
        
        //detectorT.rotation = Quaternion.Euler(transform.rotation.x, originalObj.transform.rotation.y, transform.rotation.z); 
    }

    public void RotateDetector ()
    {
        //detectorT.rotation = Quaternion.Euler(transform.rotation.x, originalObj.transform.rotation.y, transform.rotation.z);
        //detectorT.position = new Vector3(detectorT.position.x + -0.01774175f, detectorT.position.y, detectorT.position.z);

    }

    public void RotateDetectorOriginal ()
    {
        //detectorT.rotation = Quaternion.Euler(transform.rotation.x, originalObj.transform.rotation.y - 180 , transform.rotation.z);
        //detectorT.position = new Vector3(detectorT.position.x + -0.01774175f, detectorT.position.y, detectorT.position.z);

    }
}
