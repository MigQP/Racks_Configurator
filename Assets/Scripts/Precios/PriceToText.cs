using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceToText : MonoBehaviour
{
    /*WRITE PRICE IN UI*/

    public Text _priceText;
    // Start is called before the first frame update
    void Start()
    {
        _priceText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        // REGRESAR PRECIO A CERO
        if (PriceManager._furnitureValue < 0)
        {
            PriceManager._furnitureValue = 0;
        }

        _priceText.text = "Precio: $" + PriceManager._furnitureValue.ToString();
    }
}
