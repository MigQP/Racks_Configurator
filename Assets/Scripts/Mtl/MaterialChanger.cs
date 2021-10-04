using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public Material[] _originalMaterialSet;
    public Material _pendingMat;

    // Start is called before the first frame update
    void Start()
    {
        MaterialManager.soporteMaterial = _originalMaterialSet[2];
        MaterialManager.conectorMaterial = _originalMaterialSet[1];
        MaterialManager.baseMaterial = _originalMaterialSet[0];
        MaterialManager.pendingMaterial = _pendingMat;
    }

    public void ChangeBaseMaterial (Material _baseMat)
    {
        MaterialManager.baseMaterial = _baseMat;
    }

    public void ChangeConectorMaterial (Material _conMat)
    {
        MaterialManager.baseMaterial = _conMat;
    }

    public void ChangeSoporteMaterial(Material _sopMat)
    {
        MaterialManager.soporteMaterial = _sopMat;
    }



}
