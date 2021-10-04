using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LanePoints01 : MonoBehaviour
{
    public List<GameObject> downRacks = new List<GameObject>();
    public List<GameObject> GetColliders() { return downRacks; }


    public GameObject lowestObj;

    public GameObject[] middleObj;

    public GameObject[] middlePendingObj;

    public bool isDownLeftCLear;
    public bool isDownRightClear;

    public float _moduleWidth;
    public float _rightWidth;
    public float _leftWidth;

    public float leftSeparation;

    public BuildRuntime01 stacksManager;

    private GameObject mainObj;

    public GameObject[] DownSideTriggers;

    public float setWidth;
    private void Awake()
    {

        //StartCoroutine(TurnOnDownSide());
        setWidth = _moduleWidth;
    }

    private void Start()
    {
        StartCoroutine(TurnOnDownSide());
        downRacks.Clear();
        stacksManager = FindObjectOfType<BuildRuntime01>();
        mainObj = transform.parent.parent.gameObject;
    }

    
    IEnumerator TurnOnDownSide ()
    {
        DownSideTriggers[0].SetActive(false);
        DownSideTriggers[1].SetActive(false);
        yield return new WaitForSeconds(.02f);
        DownSideTriggers[0].SetActive(true);
        DownSideTriggers[1].SetActive(true);

    }



    /*
    void Update()
    {
        for (int v = 0; v < downRacks.Count; v++)
        {
            if (downRacks[v] == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].GetComponent<CheckBuild>()._module != null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module != null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null ||
                downRacks[v] == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].GetComponent<CheckBuild>()._module != null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null ||
                downRacks[v] == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].GetComponent<CheckBuild>()._module == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null ||
                downRacks[v] == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].GetComponent<CheckBuild>()._module == null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module != null && mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
            { 
                //Destroy(mainObj);
            }
        }

    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Module")
            return;
        if (!downRacks.Contains(other.gameObject)) { downRacks.Add(other.gameObject); }
    }

    private void OnTriggerExit(Collider other)
    {
        downRacks.Remove(other.gameObject);
    }

    public void CreateRightPendingLane ()
    {
        downRacks = downRacks.Where(item => item != null).ToList();

        if (downRacks.Count == 0)
            return;

        lowestObj = downRacks.OrderByDescending(lowestObj => lowestObj.transform.position.y).Last();
        GetWidths();


        for (int i = 0; i < downRacks.Count; i++)
        {
            if (downRacks[i] == null)
            {
                downRacks.RemoveAt(i);
            }


            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
            {



                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                {
                    switch(_moduleWidth)
                    {
                        case 40:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                            }
                            break;
                        case 61:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                        case 80:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                    }

                    //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);

                    if (downRacks[i] == lowestObj)
                    {
                        switch (_moduleWidth)
                        {
                            case 40:

                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    
                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));

                                }

                                break;
                            case 61:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._pendings[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._pendings[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                break;
                            case 80:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._pendings[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._pendings[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                break;
                        }
                        //Instantiate(middlePendingObj[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                        isDownRightClear = true;

                    }

                    else
                    {
                        if (_moduleWidth == _rightWidth)
                        {
                            switch (_moduleWidth)
                            {
                                case 25:
                                    //Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    isDownRightClear = true;
                                    break;
                                case 60:
                                    //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    isDownRightClear = true;
                                    break;

                            }

                        }

                        else
                        {
                            //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                            //isDownRightClear = true;
                        }
                        //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                        //isDownRightClear = true;
                    }

                    //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                    //isDownRightClear = true;
                }

                else
                {
                    //var Example = Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                    //Example.gameObject.tag = "Pending";
                    //isDownRightClear = false;


                    if (_moduleWidth == _rightWidth)
                    {
                        switch(_rightWidth)
                        {
                            case 25:
                                //Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 40:

                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 25:
                                            Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                            break;
                                    }
                          

                                break;
                            case 60:
                                //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                }
                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                }
                                break;
                        }
                    }

                    else
                    {
                        switch(_rightWidth)
                        {
                            case 25:
                                //Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 40:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                }
                                break;
                            case 60:
                                //Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 61:

                                
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                }
                                //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                break;
                            case 80:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 80:
                                        break;
                                }
      

                                break;
                        }
                    }

                    /*
                    if (_rightWidth == 25)
                    {
                        Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                        isDownRightClear = false;
                    }

                    else
                    {
                        Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);                     
                        isDownRightClear = false;
                    }
                    */

                }

                //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                //var Example  = Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                //Example.gameObject.tag = "Pending";

            }

        }
    }

    public void CreateRightLane()
    {
        if (downRacks.Count == 0)
            return;


        for (int i = 0; i < downRacks.Count; i++)
        {

            if (downRacks[i] == null)
            {
                downRacks.Remove(downRacks[i]);
            }

            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
            {

                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                {
                    //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                    /*switch (_moduleWidth)
                    {
                        case 40:
                            if(downRacks[i].transform.rotation.y == -1)
                            {
                                Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                            }

                            else
                            {
                                Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                            }

                            break;
                        case 61:

                            break;
                        case 80:

                            break;
                    }*/

                    switch (_moduleWidth)
                    {
                        case 40:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                            }
                            break;
                        case 61:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                        case 80:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                    }
                    //Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);

                    if (downRacks[i] == lowestObj)
                    {
                        switch (_moduleWidth)
                        {
                            case 40:

                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._racks[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._racks[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));

                                }

                                break;
                            case 61:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._racks[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._racks[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                break;
                            case 80:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._racks[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._racks[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                break;
                        }
                        //Instantiate(middlePendingObj[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                        isDownRightClear = true;
                    }


                }

                else
                {
                    if (_moduleWidth == _rightWidth)
                    {
                        switch (_rightWidth)
                        {
                            case 25:
                                Instantiate(middleObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                break;
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                        break;
                                }
                                break;
                            case 60:
                                Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                    case 45:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                    case 60:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                }
                                break;
                        }
                    }

                    else
                    {
                        switch (_rightWidth)
                        {
                            case 25:
                                Instantiate(middleObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                break;
                            case 40:
                                switch (_moduleWidth)
                                {
                                    case 40:

                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                }
                                break;
                            case 60:
                                Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position, Quaternion.identity);
                                        break;
                                }
                                break;
                            case 80:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[11], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[9], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[10], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                    case 80:
                                        break;
                                }


                                break;

                        }
                    }

                    //Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);


                }

            }
        }
    }

    public void CreateLefttPendingLane()
    {
        
        downRacks = downRacks.Where(item => item != null).ToList();
        

        if (downRacks.Count == 0)
            return;

        lowestObj = downRacks.OrderByDescending(lowestObj => lowestObj.transform.position.y).Last();
        GetWidths();


        for (int i = 0; i < downRacks.Count; i++)
        {
            if (downRacks[i] == null)
            {
                downRacks.RemoveAt(i);
            }


            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
            {



                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                {
                    switch (_moduleWidth)
                    {
                        case 40:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        //Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                       Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);
                                    }
                                    //Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    break;
                            }
                            break;
                        case 61:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                        case 80:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 25:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 45:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                                case 60:
                                    if (downRacks[i].transform.rotation.y == 0)
                                    {
                                        Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                    }

                                    else
                                    {
                                        Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    }
                                    break;
                            }
                            break;
                    }

                    if (downRacks[i] == lowestObj)
                    {
                        switch(_moduleWidth)
                        {
                            case 40:
                                Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                break;
                            case 61:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._pendings[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._pendings[4], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                break;
                            case 80:
                                if (lowestObj.transform.rotation.y == 0)
                                {
                                    Instantiate(stacksManager._pendings[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                }
                                else
                                {
                                    //Instantiate(stacksManager._pendings[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, transform.rotation);
                                    Instantiate(stacksManager._pendings[8], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));

                                }
                                break;
                        }
                        //Instantiate(middlePendingObj[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        if (_moduleWidth == _leftWidth)
                        {
                            switch (_moduleWidth)
                            {
                                case 25:
                                    //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                    isDownLeftCLear = true;
                                    break;
                                case 40:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 25:
                                            Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                            break;
                                    }
                                    break;
                                case 60:
                                    //(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                    isDownLeftCLear = true;
                                    break;
                                case 61:
                                    break;
                                case 80:

                                    break;
                            }
                        }
                        else
                        {
                            //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                            //isDownLeftCLear = true;
                        }

                        //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                        //isDownLeftCLear = true;
                    }

                    //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                    //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x -leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

                    //isDownLeftCLear = true;
                }

                else
                {


                    /*
                    if (_leftWidth == 25 && _leftWidth != _moduleWidth)
                    {
                        Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);

                        isDownLeftCLear = false;
                    }
                    if (_leftWidth == 60 && _leftWidth != _moduleWidth)
                    {
                        if (_moduleWidth == 25)
                        {
                            Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

                            isDownLeftCLear = false;
                        }

                        else
                        {

                            Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

                            isDownLeftCLear = false;
                        }

                        //var Example = Instantiate(middlePendingObj[0], new Vector3 (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x -leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                        //Example.gameObject.tag = "Pending";
                        //isDownLeftCLear = false;
                    }

                    if (_leftWidth == _moduleWidth)
                    {
                        // 27/06/2021 CORREGIR AQUI
                        //Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

                        //isDownLeftCLear = false;
                    }
                    */

                    if (_moduleWidth == _leftWidth)
                    {
                        switch(_leftWidth)
                        {
                            case 25:
                                //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                }
                                break;
                            case 60:
                                //Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._pendings[11], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                    case 45:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._pendings[9], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                    case 60:
                                        if (downRacks[i].transform.rotation.y == 0)
                                        {
                                            Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                        }

                                        else
                                        {
                                            Instantiate(stacksManager._pendings[10], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch(_leftWidth)
                        {
                            case 25:
                                //Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x , downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 60:
                                //Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[3], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[1], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[2], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        
                                        break;

                                }
                                //var
                                break;
                            case 61:

                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._pendings[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._pendings[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._pendings[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                }
                                //ACA
                                break;
                            case 80:
                                break;
                        }
                    }

                }

                //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                //var Example  = Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                //Example.gameObject.tag = "Pending";

            }

        }
    }

    public void CreateLeftLane()
    {
        if (downRacks.Count == 0)
            return;


        for (int i = 0; i < downRacks.Count; i++)
        {

            if (downRacks[i] == null)
            {
                downRacks.Remove(downRacks[i]);
            }

            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
            {
                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                {
                    switch(_moduleWidth)
                    {
                        case 40:
                            Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), transform.rotation);
                            break;
                        case 61:
                            if (downRacks[i].transform.rotation.y == 0 )
                            {
                                Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                            }
                            else
                            {
                                Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), transform.rotation);
                            }

                            break;
                        case 80:
                            if (downRacks[i].transform.rotation.y == 0)
                            {
                                Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                            }
                            else
                            {
                                Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), transform.rotation);
                            }
                            break;
                    }


                        //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                        //Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x -leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), transform.rotation);

                    }

                else
                {

                    /*
                    if (_leftWidth == 25 && _leftWidth != _moduleWidth)
                    {
                        Instantiate(middleObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);

                    }

                    if (_leftWidth == 60 && _leftWidth != _moduleWidth)
                    {  
                        if (_moduleWidth == 25)
                        {
                            Instantiate(middleObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                        }

                        else
                        {
                            Instantiate(middleObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                        }

                        //Instantiate(middleObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                    }




                    if (_leftWidth == _moduleWidth)
                    {

                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x -leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                    }


                    //Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.identity);
                    */
                    
                    
                    if (_moduleWidth == _leftWidth)
                    {
                        //Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

                        switch(_moduleWidth)
                        {
                            case 40:
                                /*if (transform.rotation.y == 0)
                                {
                                    Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), transform.rotation);
                                }
                                else 
                                {
                                    Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                }*/

                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, transform.rotation);
                                        break;
                                }
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        break;
                                }

                                break;
                            /*case 61:
                               
                                break;*/
                            case 80:

                                break;
                        }
                    }

                    else
                    {
                        switch(_leftWidth)
                        {
                            case 25:
                                Instantiate(middleObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                break;
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[3], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[1], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[2], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));

                                        break;

                                }
                                //var
                                break;
                            case 60:
                                Instantiate(middleObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                break;
                            case 61:
                                switch(_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                break;
                                        }
                                        break;
                                }
                                /*switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position, Quaternion.identity);
                                        break;
                                }*/
                                break;
                            
                        }
                    }
                    
                }

            }
        }
    }

    public void GetWidths()
    {
        //_rightWidth = DownSideTriggers[0].GetComponent<FixedWidth>().directionWidth;
        //_leftWidth = DownSideTriggers[1].GetComponent<FixedWidth>().directionWidth;

        if (DownSideTriggers[0].GetComponent<FixedWidth>().directionWidth == 0)
        {
            //_rightWidth = _moduleWidth;
            //_rightWidth = setWidth;
            if (ModuleCornerManager.setWidth == 0)
            {
               _rightWidth = setWidth;
            }

            else
            {
                _rightWidth = ModuleCornerManager.setWidth;
            }
        }

        else
        {
            _rightWidth = DownSideTriggers[0].GetComponent<FixedWidth>().directionWidth;
        }

        if (DownSideTriggers[1].GetComponent<FixedWidth>().directionWidth == 0)
        {
            //_leftWidth = _moduleWidth;
            //_leftWidth = setWidth;
            if (ModuleCornerManager.setWidth == 0)
            {
                _leftWidth = setWidth;
            }

            else
            {
                _leftWidth = ModuleCornerManager.setWidth;
            }
        }

        else
        {
            _leftWidth = DownSideTriggers[1].GetComponent<FixedWidth>().directionWidth;
        }
    
        /*

            if (mainObj.transform.rotation.y == lowestObj.transform.rotation.y)
            {
                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null)
                {


                    _leftWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
                }

                else
                {
                    _leftWidth = _moduleWidth;
                }

                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module != null)
                {


                    _rightWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
                }

                else
                {
                    _rightWidth = _moduleWidth;
                }
            }

            else
            {
                
                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null)
                {


                    _rightWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
                }

                else
                {
                    _rightWidth = _moduleWidth;
                }

                if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module != null)
                {


                    _leftWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
                }

                else
                {
                    _leftWidth = _moduleWidth;
                }
                
            }
        
        */

        

        /*
        
        if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null)
        {


            _leftWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
        }

        else
        {
            _leftWidth = _moduleWidth;
        }

        if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module != null)
        {


            _rightWidth = lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width;
        }

        else
        {
            _rightWidth = _moduleWidth;
        }
        
        */

    }


    public void SetLowest ()
    {
        downRacks = downRacks.Where(item => item != null).ToList();


        if (downRacks.Count == 0)
            return;

        lowestObj = downRacks.OrderByDescending(lowestObj => lowestObj.transform.position.y).Last();

        GetWidths();


        StartCoroutine(slr());

    }

    public void SetLowestLane()
    {
        downRacks = downRacks.Where(item => item != null).ToList();


        if (downRacks.Count == 0)
            return;

        lowestObj = downRacks.OrderByDescending(lowestObj => lowestObj.transform.position.y).Last();

        GetWidths();

    }

    IEnumerator slr ()
    {
        yield return new WaitForSeconds(.1f);

        for (int i = 0; i < downRacks.Count; i++)
        {

            downRacks[i].GetComponent<ConcurrentSpawn>().NewPendingLanes();
            //downRacks[i].GetComponent<ConcurrentSpawn>().CreateNewLeftRack(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform);
        }


    }

    public void NewLeftLane ()
    {
        /*for (int i = 0; i < downRacks.Count; i++)
        {
            if (downRacks[i] != lowestObj)
            {
                downRacks[i].GetComponent<ConcurrentSpawn>().CreateNewRightRack(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform);

            }


            if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
            {
                lowestObj.GetComponent<ConcurrentSpawn>().CreateNewRightRack(lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform);
            }

            downRacks[i].GetComponent<ConcurrentSpawn>().CreateNewLeftRack(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform);
        }
        */



        for (int i = 0; i < downRacks.Count; i++)
        { 
            /*
            if (mainObj.transform.rotation.y == downRacks[i].transform.rotation.y)
            {
                Debug.Log("MISMO SENTIDO");
                if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                {
                    if (_moduleWidth == _leftWidth)
                    {
                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);
                    }


                    else
                    {
                        switch (_leftWidth)
                        {
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;

                                }
                                break;
                            case 61:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                        }
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                }
                                break;
                        }

                        //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);

                    }

                }
            }

            else
            {
                Debug.Log("GIRAR TRANSFORMS");

                if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                {
                    if (_moduleWidth == _rightWidth)
                    {
                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                    }

                    else
                    {
                        switch (_rightWidth)
                        {
                            case 40:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                        }
                                        break;
                                }

                                //Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                }
                                break;
                        }

                        //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                    }

                }

            }
            */
            
            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
            {
                if(_moduleWidth == _leftWidth)
                {
                    Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);
                }


                else
                {
                    switch(_leftWidth)
                    {
                        case 40:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 35:
                                    Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                    break;
                                case 25:
                                    Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                    break;
                                case 45:
                                    Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                    break;
                                case 60:
                                    Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                    break;
                                
                            }
                            break;
                        case 61:
                            switch (_moduleWidth)
                            {
                                case 40:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 35:
                                            Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                        case 25:
                                            Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                    }
                                    break;
                                case 61:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 25:
                                            Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                            break;
                                    }
                                    break;
                                case 80:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 35:
                                            Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                            break;
                                        case 25:
                                            Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                            break;
                                    }
                                    break;
                            }

                            break;
                        case 80:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 35:
                                    Instantiate(stacksManager._racks[8], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                    break;
                                case 25:
                                    Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                    break;
                                case 45:
                                    Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                    break;
                                case 60:
                                    Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                    break;
                            }
                            break;
                    }

                    //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);

                }

            }

            

        }
    }

    public void NewRightLane()
    {
        /*
        for (int i = 0; i < downRacks.Count; i++)
        {
            if (downRacks[i] != lowestObj)
            {
                downRacks[i].GetComponent<ConcurrentSpawn>().CreateNewRightRack(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);

            }
            

            if (lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
            {
                lowestObj.GetComponent<ConcurrentSpawn>().CreateNewRightRack(lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
            }
            

          
            //downRacks[i].GetComponent<ConcurrentSpawn>().CreateNewRightRack(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
        }
        */



        for (int i = 0; i < downRacks.Count; i++)
        {
            /*
            if (mainObj.transform.rotation.y == downRacks[i].transform.rotation.y)
            {
                Debug.Log("MISMO SENTIDO");
                if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                {
                    if (_moduleWidth == _rightWidth)
                    {
                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                    }

                    else
                    {
                        switch (_rightWidth)
                        {
                            case 40:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                                break;
                                        }
                                        break;
                                }

                                //Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                break;
                            case 61:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                        break;
                                }
                                break;
                        }

                        //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                    }

                }
            }

            else
            {
                Debug.Log("GIRAR TRANSFORMS");
                if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                {
                    if (_moduleWidth == _leftWidth)
                    {
                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);
                    }


                    else
                    {
                        switch (_leftWidth)
                        {
                            case 40:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                        break;

                                }
                                break;
                            case 61:
                                switch (_moduleWidth)
                                {
                                    case 40:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 61:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[1].transform.rotation);
                                                break;
                                        }
                                        break;
                                    case 80:
                                        switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                        {
                                            case 25:
                                                Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                            case 45:
                                                Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                            case 60:
                                                Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                                break;
                                        }
                                        break;
                                }

                                break;
                            case 80:
                                switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                {
                                    case 25:
                                        Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                    case 45:
                                        Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                    case 60:
                                        Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[3].transform.rotation);
                                        break;
                                }
                                break;
                        }

                        //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.rotation);

                    }

                }
            }
            */

            
            if (downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].GetComponent<CheckBuild>()._module == null)
            {
                if (_moduleWidth == _rightWidth)
                {
                    Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                }

                else
                {
                    switch (_rightWidth)
                    {
                        case 40:
                            switch(_moduleWidth)
                            {
                                case 40:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {

                                        case 25:
                                            Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                    }
                                    break;
                                case 61:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 35:
                                            Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 25:
                                            Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                    }
                                    break;
                                case 80:
                                    switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                                    {
                                        case 35:
                                            Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 25:
                                            Instantiate(stacksManager._racks[3], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                            break;
                                        case 45:
                                            Instantiate(stacksManager._racks[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                            break;
                                        case 60:
                                            Instantiate(stacksManager._racks[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                            break;
                                    }
                                    break;
                            }

                            //Instantiate(stacksManager._racks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                            break;
                        case 61:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 35:
                                    switch (_moduleWidth)
                                    {
                                        case 40:
                                            Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 61:
                                            Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                            break;
                                        case 80:
                                            Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                            break;
                                    }
                                    //Instantiate(stacksManager._racks[4], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                    break;
                                case 25:
                                    Instantiate(stacksManager._racks[7], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                    break;
                                case 45:
                                    Instantiate(stacksManager._racks[5], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                    break;
                                case 60:
                                    Instantiate(stacksManager._racks[6], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[0].transform.rotation);
                                    break;
                            }

                            break;
                        case 80:
                            switch (downRacks[i].GetComponent<ConcurrentSpawn>().Height)
                            {
                                case 35:
                                    Instantiate(stacksManager._racks[8], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                    break;
                                case 25:
                                    Instantiate(stacksManager._racks[11], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                    break;
                                case 45:
                                    Instantiate(stacksManager._racks[9], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                    break;
                                case 60:
                                    Instantiate(stacksManager._racks[10], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._otherPoints[2].transform.rotation);
                                    break;
                            }
                            break;
                    }

                    //Instantiate(downRacks[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position.z), downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.rotation);
                }

            }
            
            

        }

    }

}
