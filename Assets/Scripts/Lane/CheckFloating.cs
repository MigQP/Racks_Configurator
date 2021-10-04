using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloating : MonoBehaviour
{

    /*THIS USES THE INDIVIDUAL RACK FOUR TRIGGERS (UP, DOWN AND SIDES) TO CHECK IF THE RACK IS FLOATING OR SUSPENDED IF SO, DELETE IT*/

    private GameObject mainObj;

    public GameObject[] moduleTriggers;
    bool checkTriggers;

    // Start is called before the first frame update
    void Start()
    {
        mainObj = transform.parent.gameObject;
        StartCoroutine(StartCheck());
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkTriggers)
            return;
        if (moduleTriggers[0].GetComponent<CheckBuild>()._module == null && moduleTriggers[1].GetComponent<CheckBuild>()._module == null && moduleTriggers[2].GetComponent<CheckBuild>()._module == null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }

        if (moduleTriggers[0].GetComponent<CheckBuild>()._module != null && moduleTriggers[1].GetComponent<CheckBuild>()._module == null && moduleTriggers[2].GetComponent<CheckBuild>()._module == null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }

        if (moduleTriggers[0].GetComponent<CheckBuild>()._module != null && moduleTriggers[1].GetComponent<CheckBuild>()._module == null && moduleTriggers[2].GetComponent<CheckBuild>()._module == null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            //Destroy(mainObj);
        }

        if (moduleTriggers[0].GetComponent<CheckBuild>()._module == null && moduleTriggers[1].GetComponent<CheckBuild>()._module != null && moduleTriggers[2].GetComponent<CheckBuild>()._module == null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }

        
        if (moduleTriggers[0].GetComponent<CheckBuild>()._module == null && moduleTriggers[1].GetComponent<CheckBuild>()._module == null && moduleTriggers[2].GetComponent<CheckBuild>()._module != null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }


        if (moduleTriggers[0].GetComponent<CheckBuild>()._module != null && moduleTriggers[1].GetComponent<CheckBuild>()._module != null && moduleTriggers[2].GetComponent<CheckBuild>()._module == null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }

        if (moduleTriggers[0].GetComponent<CheckBuild>()._module != null && moduleTriggers[1].GetComponent<CheckBuild>()._module == null && moduleTriggers[2].GetComponent<CheckBuild>()._module != null && moduleTriggers[3].GetComponent<CheckBuild>()._module == null)
        {
            Destroy(mainObj);
        }
    }

    IEnumerator StartCheck ()
    {
        yield return new WaitForSeconds(.5f);
        checkTriggers = true;
    }
}
