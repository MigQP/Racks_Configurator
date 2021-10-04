using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneDetector : MonoBehaviour
{
    /*CALLS TOTAL HEIGHT OBJECT AND  SETS ITS HEIGHT ACOORDING */


    private TotalHeight _heightManager;


    // Start is called before the first frame update
    void Start()
    {
        _heightManager = FindObjectOfType<TotalHeight>();
        StartCoroutine(WaitHeight());
    }

    IEnumerator WaitHeight ()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, _heightManager._cubeHeight, gameObject.transform.localScale.z);
    }

    
}
