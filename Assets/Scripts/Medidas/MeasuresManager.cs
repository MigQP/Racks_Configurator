using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeasuresManager : MonoBehaviour
{
    /*TOGGLE MANAGER TO SHOW TOTAL MEASURE OF FURNITURE OBJECT AND INDIVIDUAL MEASURES FOR EACH RACK*/

    //ALSO REFRESH MATERIALS WHEN CHANGED

    public GameObject[] _measureObjs;

    private Toggle _showMeasures;

    // Start is called before the first frame update
    void Start()
    {
        _showMeasures = GetComponent<Toggle>();
    }

    private void Update()
    {
        // GET ALL RACKS AND MEASURES
        _measureObjs = GameObject.FindGameObjectsWithTag("Module");

        for (int i = 0; i < _measureObjs.Length; i++)
        {
            _measureObjs[i].GetComponent<MeasureModule>().ShowSize(_showMeasures.isOn);
        }
    }

    public void ShowMeasures()
    {

        for (int i = 0; i < _measureObjs.Length; i++)
        {
            //_measureObjs[i].SetActive(_showMeasures.isOn);
            //_measureObjs[i].GetComponent<MeasureModule>().ShowSize(_showMeasures.isOn);
        }

    }


    // SET NEW MATERIAL AND REFRESH OBJECT MATERIALS ARRAY

    public void ChangeBaseMat (Material _baseMat)
    {
        MaterialManager.baseMaterial = _baseMat;

        for (int i = 0; i < _measureObjs.Length; i++)
        {

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 1) // 6 MATERIALES EN TOTAL
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.conectorMaterial; // set new material
                mats[1] = MaterialManager.soporteMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 2)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.soporteMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 3)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 4)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.soporteMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 5)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.conectorMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

        }
    }

    public void ChangConectorMat(Material _baseMat)
    {
        MaterialManager.conectorMaterial = _baseMat;

        for (int i = 0; i < _measureObjs.Length; i++)
        {

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 1) // 6 MATERIALES EN TOTAL
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.conectorMaterial; // set new material
                mats[1] = MaterialManager.soporteMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 2)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.soporteMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 3)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 4)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.soporteMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 5)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.conectorMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

        }
    }

    public void ChangeSoporteMat(Material _baseMat)
    {
        MaterialManager.soporteMaterial = _baseMat;

        for (int i = 0; i < _measureObjs.Length; i++)
        {

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 1) // 6 MATERIALES EN TOTAL
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.conectorMaterial; // set new material
                mats[1] = MaterialManager.soporteMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 2)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.soporteMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.baseMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 3)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array

            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 4)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.conectorMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.soporteMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

            if (_measureObjs[i].GetComponent<MeasureModule>().rackType == 5)
            {
                Material[] mats = _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials;  // copy of materials array.

                mats[0] = MaterialManager.baseMaterial; // set new material
                mats[1] = MaterialManager.conectorMaterial; // set new material
                mats[2] = MaterialManager.soporteMaterial; // set new material
                mats[3] = MaterialManager.conectorMaterial; // set new material
                mats[4] = MaterialManager.conectorMaterial; // set new material
                mats[5] = MaterialManager.conectorMaterial;

                _measureObjs[i].GetComponent<MeasureModule>().moduleRend.materials = mats; // assign updated array to materials array
            }

        }
    }
}

