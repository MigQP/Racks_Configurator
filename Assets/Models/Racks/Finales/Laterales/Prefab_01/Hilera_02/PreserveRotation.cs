using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveRotation : MonoBehaviour
{
    public GameObject mainObj;
    public Transform insideObj;
    // Start is called before the first frame update
    void Start()
    {
        insideObj = GetComponent<Transform>();
        if (mainObj.transform.rotation.y != 0)
        {
            //mainObj.transform.position = new Vector3(transform.position.x - 0.075083f, transform.position.y, transform.position.z);
            mainObj.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            //insideObj.position = new Vector3(transform.position.x + 0.025032f, transform.position.y, transform.position.z);
            insideObj.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
        }

        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
