using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExtrasPrice : MonoBehaviour
{
    // ADD OR REST EXTRAS PRICE 

    public float Price;

    // Start is called before the first frame update
    void Start()
    {
        PriceManager._furnitureValue += Price;
    }

    private void OnDestroy()
    {
        PriceManager._furnitureValue -= Price;
    }

}
