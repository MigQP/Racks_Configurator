using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBuild : MonoBehaviour
{
    /*TURN ON COLLIDER AFTER SPAWN AND CHECK IF THERE IS OTHER RACKS AROUND, IF SO DON'T SHOW THE SPAWN BUTTON IN THOSE POSITIONS*/

    public GameObject spawnButton;
    public GameObject _module;

    public bool _canSpawn = true;

    private BoxCollider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        StartCoroutine(StartColliders());
        _canSpawn = true;
        _module = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnButton == null)
            return;

        if (_module == null)
        {
            spawnButton.SetActive(true);
        }

        else
        {
            spawnButton.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Module")
        {
            //_canSpawn = false;
            _module = other.gameObject;
        }
    }



    /*
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Module")
        {
            //_canSpawn = false;
            //_module = other.gameObject;
        }

        else
        {
            //_module = null;
        }
       
    }
    */
    


    IEnumerator StartColliders()
    { 
        _collider.enabled = false;
        yield return new WaitForSeconds(.2f);
        _collider.enabled = true;
    }
}
