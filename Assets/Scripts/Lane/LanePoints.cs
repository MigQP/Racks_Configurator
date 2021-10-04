using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LanePoints : MonoBehaviour
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

    private void Start()
    {
        downRacks.Clear();
    }

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
                    //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);

                    if (downRacks[i] == lowestObj)
                    {
                        Instantiate(middlePendingObj[2], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                        isDownRightClear = true;

                    }

                    else
                    {
                        if (_moduleWidth == _rightWidth)
                        {
                            switch (_moduleWidth)
                            {
                                case 25:
                                    Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                    isDownRightClear = true;
                                    break;
                                case 60:
                                    Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
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
                                Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 60:
                                Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                        }
                    }

                    else
                    {
                        switch(_rightWidth)
                        {
                            case 25:
                                Instantiate(middlePendingObj[1], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
                                break;
                            case 60:
                                Instantiate(middlePendingObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                                isDownRightClear = false;
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
                    Instantiate(downRacks[i], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
                    
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
                            case 60:
                                Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
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
                            case 60:
                                Instantiate(middleObj[0], downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform.position, Quaternion.identity);
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
                    if (downRacks[i] == lowestObj)
                    {
                        Instantiate(middlePendingObj[2], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        if (_moduleWidth == _leftWidth)
                        {
                            switch (_moduleWidth)
                            {
                                case 25:
                                    Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                    isDownLeftCLear = true;
                                    break;
                                case 60:
                                    Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                    isDownLeftCLear = true;
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
                                Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 60:
                                Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;

                        }
                    }
                    else
                    {
                        switch(_leftWidth)
                        {
                            case 25:
                                Instantiate(middlePendingObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x , downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
                                break;
                            case 60:
                                Instantiate(middlePendingObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                isDownLeftCLear = false;
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
                    //_laneSpawnPoints.Add(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[1].transform);
                    Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x -leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);

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
                        Instantiate(downRacks[i], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x - leftSeparation, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);


                    }

                    else
                    {
                        switch(_leftWidth)
                        {
                            case 25:
                                Instantiate(middleObj[1], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                break;
                            case 60:
                                Instantiate(middleObj[0], new Vector3(downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.x, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.y, downRacks[i].GetComponent<ConcurrentSpawn>()._spawnPoints[2].transform.position.z), Quaternion.identity);
                                break;
                        }
                    }
                    
                }

            }
        }
    }

    void GetWidths()
    {
        //_rightWidth = lowestObj.GetComponent<ConcurrentSpawn>().Width;


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

}
