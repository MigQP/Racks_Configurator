using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLane : MonoBehaviour
{
    /*ERASURE OF SINGULAR VERTICAL LANE AND MOVEMENT OF THE REST TO PUT THEM TOGETHER AGAIN WITH DISTANCE ACCORDING TO RACK WIDTH*/


    public List<GameObject> upRacks = new List<GameObject>();
    public List<GameObject> GetColliders() { return upRacks; }

    public GameObject mainObj;

    private MeasuresManager allModulesManager;
    
    private float moduleWidth;
    private float movingDistance;

    public float setWidth;

    // Start is called before the first frame update

    void Start()
    {

        allModulesManager = FindObjectOfType<MeasuresManager>();
        upRacks.Clear();
        mainObj = transform.parent.gameObject;
        moduleWidth = mainObj.GetComponent<ConcurrentSpawn>().Width;


        // MOVE DISTANCE SET
        switch (moduleWidth)
        {
            case 40:
                movingDistance = 1.1990001f;
                break;
            case 61:
                movingDistance = 1.8059f;
                break;
            case 80:
                movingDistance = 2.406f;
                break;
        }

        //setWidth = moduleWidth;
        if (ModuleCornerManager.setWidth == 0)
        {
            setWidth = moduleWidth;
        }

        else
        {
            setWidth = ModuleCornerManager.setWidth;
        }
    }

    private void Update()
    {
        if (ModuleCornerManager.setWidth == 0)
        {
            setWidth = moduleWidth;
        }

        else
        {
            setWidth = ModuleCornerManager.setWidth;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Module")
            return;
        if (!upRacks.Contains(other.gameObject)) { upRacks.Add(other.gameObject); }

    }

    private void OnTriggerExit(Collider other)
    {
        upRacks.Remove(other.gameObject);
    }



    public void DestroyLane ()
    {

        if (mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null)
        {     


            for (int m = 0; m < allModulesManager._measureObjs.Length; m++)
            {
                switch (moduleWidth)
                {
                    case 40:
                        if (mainObj.transform.rotation.y != 0)
                        {
                            // 29/07/2021 ULTIMA CORRECCION
                            if (mainObj.transform.rotation.y < 0 && mainObj.transform.rotation.y > -.1f)
                            {
                                mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2] = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[1];
                            }
                            // 29/07/2021 ULTIMA CORRECCION

                            if (allModulesManager._measureObjs[m].transform.position.x < mainObj.transform.position.x)
                            {
                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }
                        }

                        else
                        //if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y <= 2 && mainObj.transform.rotation.y >= -2)
                        {
                            if (allModulesManager._measureObjs[m].transform.position.x > mainObj.transform.position.x)
                            {
                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }
                        }
                        break;
                    case 61:
                        if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y < 1 && mainObj.transform.rotation.y > -1)
                        {
                            if (allModulesManager._measureObjs[m].transform.position.x < mainObj.transform.position.x)
                            {
                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }
                        }
                        else
                        {
                            if (allModulesManager._measureObjs[m].transform.position.x > mainObj.transform.position.x)
                            {
                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }
                        }
                        break;
                    case 80:
                        if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y < 1 && mainObj.transform.rotation.y > -1)
                        {
                            if (allModulesManager._measureObjs[m].transform.position.x < mainObj.transform.position.x)
                            {

                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }


                        }
                        else
                        {
                            if (allModulesManager._measureObjs[m].transform.position.x > mainObj.transform.position.x)
                            {
                                allModulesManager._measureObjs[m].transform.parent = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;
                            }
                        }
                        break;
                }



            }

        }

        foreach (GameObject module in upRacks)
        {
            Destroy(module);
        }
    }


    public void EndParent()
    {
        
        for (int i = 0; i < allModulesManager._measureObjs.Length; i++)
        { 
            allModulesManager._measureObjs[i].transform.parent = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
        }

    }

    private void OnDestroy()
    {
        /*
        if (mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module != null)
        {
            mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponentInChildren<UpLane>().ParentLane();
        }
        */


        Transform movedLane = mainObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.transform;

        switch (moduleWidth)
        {
            case 40:
                if (mainObj.transform.rotation.y != 0)
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x + movingDistance, movedLane.position.y, movedLane.position.z);
                }

                else
                //if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y < 2 && mainObj.transform.rotation.y > -2)
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x - movingDistance, movedLane.position.y, movedLane.position.z);
                }

                Debug.Log(mainObj.transform.rotation.y);
                break;
            case 61:
                if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y < 1 && mainObj.transform.rotation.y > -1)
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x + movingDistance, movedLane.position.y, movedLane.position.z);
                }

                else
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x - movingDistance, movedLane.position.y, movedLane.position.z);
                }
                
                break;
            case 80:
                if (mainObj.transform.rotation.y == 0 || mainObj.transform.rotation.y < 1 && mainObj.transform.rotation.y > -1)
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x + movingDistance, movedLane.position.y, movedLane.position.z);
                }

                else
                {
                    movedLane.transform.position = new Vector3(movedLane.position.x - movingDistance, movedLane.position.y, movedLane.position.z);

                }

                Debug.Log(mainObj.transform.rotation.y);
                break;

        }


        

        //movedLane.transform.position = new Vector3(movedLane.position.x + 1.1990001f, movedLane.position.y, movedLane.position.z);

        EndParent();
    }

    public void ParentLane ()
    {
        for (int i = 0; i < upRacks.Count; i++)
        {
            upRacks[i].transform.parent = mainObj.transform;
        }
    }



}
