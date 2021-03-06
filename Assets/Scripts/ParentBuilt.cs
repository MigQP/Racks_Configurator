using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBuilt : MonoBehaviour
{ 
    /*PARENT RACKS TO MAIN GAMEOBJECT IN CASE IT IS NEEDED TO MOVE THE WHOLE FURNITURE*/


    private Transform _mainObject;

    public GameObject spawnButtons;

    void Awake()
    {
        _mainObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.transform.parent = _mainObject.transform;
        if (spawnButtons != null)
        spawnButtons.SetActive(false);
    }


}
