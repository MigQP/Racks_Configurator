using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobel : MonoBehaviour
{
    /*DEPRECATED*/

    /*TEST SYSTEM TO SPAWN RACK NEXT TO OTHER*/


    public GameObject leftFurniture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(leftFurniture, transform.position, Quaternion.identity);
    }
}
