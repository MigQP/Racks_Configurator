using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasManager : MonoBehaviour
{
    public GameObject _pressedRack;
    public Transform[] _extraObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActualRack (GameObject _selectedRack)
    {
        _pressedRack = _selectedRack;
    }

    public void SpawnExtra(Transform _extraToSpawn)
    {
        CheckPreviousExtras();
        
        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);

        var newObject = Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
        newObject.transform.localScale = new Vector3(_pressedRack.transform.localScale.x, _pressedRack.transform.localScale.y, 3); // change its local scale in x y z format
        newObject.transform.parent = _pressedRack.transform;

    }

    public void SpawnExtraRepisa(Transform _extraToSpawn)
    {
        CheckPreviousExtras();

        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);

        var newObject = Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
        newObject.transform.localScale = new Vector3((_pressedRack.transform.localScale.x / 3) * 2, _pressedRack.transform.localScale.y , 3); // change its local scale in x y z format
        newObject.transform.parent = _pressedRack.transform;

    }

    public void SpawnNewExtra(Transform _extraToSpawn)
    {
        CheckPreviousExtras();

        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);

        var newObject = Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
        newObject.transform.parent = _pressedRack.transform;

    }

    public void CheckPreviousExtras ()
    {
        if (_pressedRack.transform.childCount > 0)
        {
            foreach (Transform child in _pressedRack.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }


    public void SetNextWidth(float moduleWidth)
    {
       ModuleCornerManager.setWidth = moduleWidth;

       if (_pressedRack.transform.parent.GetComponentInChildren<LanePoints01>() != null)
        {
            _pressedRack.transform.parent.GetComponentInChildren<LanePoints01>().setWidth = moduleWidth;
            for (int i = 0; i < _pressedRack.transform.parent.GetComponentInChildren<LanePoints01>().downRacks.Count; i++)
            {
                if (_pressedRack.transform.parent.GetComponentInChildren<LanePoints01>().downRacks[i].GetComponentInChildren<LanePoints01>() != null)
                {


                    _pressedRack.transform.parent.GetComponentInChildren<LanePoints01>().downRacks[i].GetComponentInChildren<LanePoints01>().setWidth = moduleWidth;
                }
                else
                {
                    _pressedRack.transform.parent.GetComponentInChildren<LanePoints01>().downRacks[i].GetComponentInChildren<UpLane>().setWidth = moduleWidth;
                }

            }

        }
        else
        {
            _pressedRack.transform.parent.GetComponentInChildren<UpLane>().setWidth = moduleWidth;
        }
        _pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().NewPendingStacks();
    }



    // NUEVO SPAWN DE EXTRAS
 
    public void SpawnNewCajon()
    {
        CheckPreviousExtras();

        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);

        if (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height > 35)
            return;

        switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Width)
        {
            case 61:
                var newObject = Instantiate(_extraObject[0], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                newObject.transform.parent = _pressedRack.transform;
                break;
            case 80:
                var newObject1 = Instantiate(_extraObject[1], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                newObject1.transform.parent = _pressedRack.transform;
                break;
        }
    }

    public void SpawnNewRepisaPuerta()
    {
        CheckPreviousExtras();

        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);


        switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Width)
        {
            case 40:
                switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height)
                {
                    case 60:
                        var newObject = Instantiate(_extraObject[8], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject.transform.parent = _pressedRack.transform;
                        break;
                }

                break;
            case 61:
                switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height)
                {
                    case 45:
                        var newObject = Instantiate(_extraObject[7], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject.transform.parent = _pressedRack.transform;
                        break;
                }
                break;
        }
    }

    public void SpawnNewRepisaInter ()
    {
        CheckPreviousExtras();

        if (_pressedRack == null)
            return;
        //Instantiate(_extraToSpawn, _pressedRack.transform.position, Quaternion.identity);


        switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Width)
        {
            case 40:
                switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height)
                {
                    case 45:
                        var newObject = Instantiate(_extraObject[2], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject.transform.parent = _pressedRack.transform;
                        break;
                }
                break;
            case 61:
                switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height)
                {
                    case 45:
                        var newObject = Instantiate(_extraObject[3], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject.transform.parent = _pressedRack.transform;
                        break;
                    case 60:
                        var newObject1 = Instantiate(_extraObject[5], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject1.transform.parent = _pressedRack.transform;
              
                        break;
                }
                break;
            case 80:
                switch (_pressedRack.transform.parent.GetComponent<ConcurrentSpawn>().Height)
                {
                    case 45:
                        var newObject = Instantiate(_extraObject[4], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject.transform.parent = _pressedRack.transform;
                        break;
                    case 60:
                        var newObject1 = Instantiate(_extraObject[6], _pressedRack.transform.position, Quaternion.identity);  // instatiate the object
                        newObject1.transform.parent = _pressedRack.transform;
                        break;
                }
                break;
        }
    }
}
