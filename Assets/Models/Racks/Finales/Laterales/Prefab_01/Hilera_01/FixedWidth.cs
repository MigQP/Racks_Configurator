using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FixedWidth : MonoBehaviour
{

    public float directionWidth;

    public GameObject slr;

    public List<GameObject> downRacks = new List<GameObject>();
    public List<GameObject> GetColliders() { return downRacks; }
    // Start is called before the first frame update

    public ConcurrentSpawn mainObj;
    public GameObject directionToSpawn;
    public GameObject originalPos;
    public GameObject newPos;
    public int spawnNumber;

    public GameObject directionToSpawn01;
    public GameObject originalPos01;
    public GameObject newPos01;
    public int otherPointNumber;

    public GameObject directionToSpawn02;
    public GameObject originalPos02;
    public GameObject newPos02;
    public int otherPointNumber02;
    void Start()
    {
        downRacks.Clear();
        InvokeRepeating("EraseEmpty", .3f, .3f);

    }

    private void Update()
    {

        //EraseEmpty();

        /*
        if (slr == null)
        {
            directionWidth = 0;
        }

        else
        {
            directionWidth = slr.GetComponent<ConcurrentSpawn>().Width;
        }
        */

        for (int i = 0; i > downRacks.Count; i++)

        {
            if (downRacks[i] == null)
            {
                downRacks.RemoveAt(i);
            }
        }



        if (downRacks.Count == 0)
        {
            directionWidth = 0;

            //if (directionToSpawn != null)
            if (originalPos != null)
            mainObj._spawnPoints[spawnNumber] = originalPos;
            

            // ULTIMA MODIFICACION 05/08/2021
            if (originalPos01 != null)
                mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
            if (originalPos02 != null)
                mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
            // ULTIMA MODIFICACION 05/08/2021
        }

        else
        {
            //downRacks = downRacks.Where(item => item != null).ToList();

            if (downRacks.Last() == null)
            {
                directionWidth = 0;
            }

            else
            {
                if (originalPos != null)
                {
                    /*  ORIGINAL
                    if (directionWidth == mainObj.Width)
                    {

                        if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                        {
                            mainObj._spawnPoints[spawnNumber] = newPos;
                        }

                        else
                        {
                            mainObj._spawnPoints[spawnNumber] = originalPos;
                        }

                    }

                    else
                    {
                        mainObj._spawnPoints[spawnNumber] = originalPos;
                    }
                    */

                    switch (mainObj.Width)
                    {
                        case 40:
                            if (directionWidth == mainObj.Width)
                            {

                                
                                if (downRacks[0] == null)
                                    return;

                                if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                {
                                    mainObj._spawnPoints[spawnNumber] = newPos;
                                }

                                else
                                {
                                    mainObj._spawnPoints[spawnNumber] = originalPos;
                                }
                                
                            }

                            else
                            {
                                mainObj._spawnPoints[spawnNumber] = originalPos;
                            }


                            if (originalPos01 != null)
                            {
                                if (mainObj.transform.rotation.y == 0)
                                {
                                    // 27/07/2021 ULTIMA CORRECCION
                                    if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                    {
                                        mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                    }
                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                    }

                                    //mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                }

                                else
                                {
                                    mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                }
                            }

                            if (originalPos02 != null)
                            {
                                if (mainObj.transform.rotation.y == 0)
                                {
                                    // 26/07/2021 ULTIMA CORRECCION
                                    if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                    }
                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                    }

                                    //mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                }

                                else
                                {
                                    mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                }
                            }
                            break;
                        case 61:
                            if (mainObj.transform.rotation.y == 0)
                            {
                                if (directionWidth == mainObj.Width)
                                {

                                    if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                    {
                                        mainObj._spawnPoints[spawnNumber] = newPos;
                                    }

                                    else
                                    {
                                        mainObj._spawnPoints[spawnNumber] = originalPos;
                                    }

                                }

                                else
                                {
                                    mainObj._spawnPoints[spawnNumber] = originalPos;
                                }


                                if (originalPos01 != null)
                                {
                                    //mainObj._otherPoints[otherPointNumber] = newPos01.transform;

                                    if (downRacks[0].transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                    }
                                }

                                if (originalPos02 != null)
                                {

                                    
                                    if (downRacks[0].transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                    }
                                }
                            }

                            else
                            {
                                if (directionWidth == mainObj.Width)
                                {

                                    if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                    {
                                        switch (downRacks[0].transform.rotation.y)
                                        {
                                            case 0:
                                                mainObj._spawnPoints[spawnNumber] = originalPos;
                                                break;
                                            case -180:
                                                mainObj._spawnPoints[spawnNumber] = newPos;
                                                break;
                                        }
                                        //mainObj._spawnPoints[spawnNumber] = originalPos;
                                    }

                                    else
                                    {


                                        switch (downRacks[0].transform.rotation.y)
                                        {
                                            case 0:
                                                mainObj._spawnPoints[spawnNumber] = originalPos;
                                                break;
                                            case -180:
                                                mainObj._spawnPoints[spawnNumber] = newPos;
                                                break;
                                        }
                                        //mainObj._spawnPoints[spawnNumber] = newPos;
                                    }

                                }

                                else
                                {
                                    mainObj._spawnPoints[spawnNumber] = newPos;
                                }


                                if (originalPos01 != null)
                                {


                                    if (downRacks[0].transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                    }
                                }

                                if (originalPos02 != null)
                                {

                                    if (downRacks[0].transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                    }
                                }
                            }

                            /*
                            if (originalPos01 != null)
                            {
                                if (downRacks[0].transform.rotation.y == 0)
                                {
                                    mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                }

                                else
                                {
                                    mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                }
                            }

                            if (originalPos02 != null)
                            {
                                if (downRacks[0].transform.rotation.y == 0)
                                {
                                    mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                }

                                {
                                else
                                    mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                }
                            }
                            */
                            break;
                        case 80:

                            if (mainObj.transform.rotation.y == 0)
                            {
                                if (directionWidth == mainObj.Width)
                                {

                                    if (mainObj.transform.rotation.y == downRacks[0].transform.rotation.y)
                                    {
                                        mainObj._spawnPoints[spawnNumber] = newPos;
                                    }

                                    else
                                    {
                                        mainObj._spawnPoints[spawnNumber] = originalPos;
                                    }

                                }

                                else
                                {
                                    mainObj._spawnPoints[spawnNumber] = originalPos;
                                }

                                if (originalPos01 != null)
                                {
                                    if (downRacks.Last().transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                    }
                                }

                                if (originalPos02 != null)
                                {
                                    if (downRacks.Last().transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                    }
                                }
                            }
                            else
                            {
                                if (directionWidth == mainObj.Width)
                                {

                                    if (mainObj.transform.rotation.y == downRacks.Last().transform.rotation.y)
                                    {
                                        switch (downRacks.Last().transform.rotation.y)
                                        {
                                            case 0:
                                                mainObj._spawnPoints[spawnNumber] = originalPos;
                                                break;
                                            case -180:
                                                mainObj._spawnPoints[spawnNumber] = newPos;
                                                break;
                                        }
                                        //mainObj._spawnPoints[spawnNumber] = originalPos;
                                    }

                                    else
                                    {
                                        switch (downRacks.Last().transform.rotation.y)
                                        {
                                            case 0:
                                                mainObj._spawnPoints[spawnNumber] = originalPos;
                                                break;
                                            case -180:
                                                mainObj._spawnPoints[spawnNumber] = newPos;
                                                break;
                                        }
                                        //mainObj._spawnPoints[spawnNumber] = newPos;
                                    }

                                }

                                else
                                {
                                    mainObj._spawnPoints[spawnNumber] = newPos;
                                }


                                if (originalPos01 != null)
                                {
                                    if (downRacks.Last().transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                                    }
                                }

                                if (originalPos02 != null)
                                {
                                    if (downRacks.Last().transform.rotation.y == 0)
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                    }

                                    else
                                    {
                                        mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                    }
                                }
                            }
      

                            /*
                            

                            if (originalPos02 != null)
                            {
                                if (downRacks[0].transform.rotation.y == 0)
                                {
                                    mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                                }

                                else
                                {
                                    mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                                }
                            }
                            */
                            break;
                    }

                    /*
                    if (originalPos01 != null)
                    {
                        if (mainObj.transform.rotation.y == 0)
                        {
                            mainObj._otherPoints[otherPointNumber] = newPos01.transform;
                        }

                        else
                        {
                            mainObj._otherPoints[otherPointNumber] = originalPos01.transform;
                        }
                    }

                    if (originalPos02 != null)
                    {
                        if (mainObj.transform.rotation.y == 0)
                        {
                            mainObj._otherPoints[otherPointNumber02] = newPos02.transform;
                        }

                        else
                        {
                            mainObj._otherPoints[otherPointNumber02] = originalPos02.transform;
                        }
                    }
                    */
                }


                directionWidth = downRacks.Last().GetComponent<ConcurrentSpawn>().Width;
            }
            
                
            
                //return;
            //directionWidth = downRacks.Last().GetComponent<ConcurrentSpawn>().Width;
        }

        //EraseEmpty();
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Module")
        {
            slr = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        directionWidth = 0;
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


    public void EraseEmpty ()
    {
        downRacks = downRacks.Where(item => item != null).ToList();

    }
}
