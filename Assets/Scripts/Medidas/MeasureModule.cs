using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureModule : MonoBehaviour
{
    // INDIVIDUAL RACK MEASURE OBJECT MANAGER

    // ALSO SETS THE MATERIALS ON START

    public GameObject _measures;
    public MeshRenderer moduleRend;
    public int rackType;

    // Start is called before the first frame update
    void Start()
    {
        if (rackType == 1) // 6 MATERIALES EN TOTAL
        {
            Material[] mats = moduleRend.materials;  // copy of materials array.

            mats[0] = MaterialManager.conectorMaterial; // set new material
            mats[1] = MaterialManager.soporteMaterial; // set new material
            mats[2] = MaterialManager.conectorMaterial; // set new material
            mats[3] = MaterialManager.conectorMaterial; // set new material
            mats[4] = MaterialManager.conectorMaterial; // set new material
            mats[5] = MaterialManager.baseMaterial; // set new material

            moduleRend.materials = mats; // assign updated array to materials array
        }

        if (rackType == 2)
        {
            Material[] mats = moduleRend.materials;  // copy of materials array.

            mats[0] = MaterialManager.soporteMaterial; // set new material
            mats[1] = MaterialManager.conectorMaterial; // set new material
            mats[2] = MaterialManager.conectorMaterial; // set new material
            mats[3] = MaterialManager.conectorMaterial; // set new material
            mats[4] = MaterialManager.conectorMaterial; // set new material
            mats[5] = MaterialManager.baseMaterial; // set new material

            moduleRend.materials = mats; // assign updated array to materials array

        }

        if (rackType == 3)
        {
            Material[] mats = moduleRend.materials;  // copy of materials array.

            mats[0] = MaterialManager.baseMaterial; // set new material
            mats[1] = MaterialManager.conectorMaterial; // set new material
            mats[2] = MaterialManager.soporteMaterial; // set new material

            moduleRend.materials = mats; // assign updated array to materials array

        }

        if (rackType == 4)
        {
            Material[] mats = moduleRend.materials;  // copy of materials array.

            mats[0] = MaterialManager.baseMaterial; // set new material
            mats[1] = MaterialManager.conectorMaterial; // set new material
            mats[2] = MaterialManager.conectorMaterial; // set new material
            mats[3] = MaterialManager.conectorMaterial; // set new material
            mats[4] = MaterialManager.conectorMaterial; // set new material
            mats[5] = MaterialManager.soporteMaterial;

            moduleRend.materials = mats; // assign updated array to materials array
        }

        if (rackType == 5)
        {
            Material[] mats = moduleRend.materials;  // copy of materials array.

            mats[0] = MaterialManager.baseMaterial; // set new material
            mats[1] = MaterialManager.conectorMaterial; // set new material
            mats[2] = MaterialManager.soporteMaterial; // set new material
            mats[3] = MaterialManager.conectorMaterial; // set new material
            mats[4] = MaterialManager.conectorMaterial; // set new material
            mats[5] = MaterialManager.conectorMaterial;

            moduleRend.materials = mats; // assign updated array to materials array
        }
    }


    // GET MEASURE OBJECT 
    public void ShowSize (bool active)
    {
        _measures.SetActive(active);
    }
}
