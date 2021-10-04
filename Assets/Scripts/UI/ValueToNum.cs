using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueToNum : MonoBehaviour
{
    /* WRITING OF SLIDER TEXT VALUE NEXT TO
     IT IS FIXED  BECAUSE THE FURNITURE STARTING SIZE IS LIMITED*/ 

    public Slider _measureAnchuraSlider;
    public Slider _measureAlturaSlider;

    public Text _anchuraWriter;
    public Text _alturaWriter;
    // Update is called once per frame
    void Update()
    {
        if (_measureAnchuraSlider.value == 0)
        {
            _anchuraWriter.text = null;
        }

        if (_measureAlturaSlider.value == 0)
        {
            _alturaWriter.text = null;
        }

        switch (_measureAlturaSlider.value)
        {
            case 1:
                _alturaWriter.text = "35";
                break;
            case 2:
                _alturaWriter.text = "80";
                break;
            case 3:
                _alturaWriter.text = "140";
                break;
            case 4:
                _alturaWriter.text = "165";
                break;
            case 5:
                _alturaWriter.text = "210";
                break;
            case 6:
                _alturaWriter.text = "270";
                break;
            case 7:
                _alturaWriter.text = "295";
                break;
            case 8:
                _alturaWriter.text = "340";
                break;
        }

        switch (_measureAnchuraSlider.value)
        {
            case 1:
                _anchuraWriter.text = "40";
                break;
            case 2:
                _anchuraWriter.text = "100";
                break;
            case 3:
                _anchuraWriter.text = "180";
                break;
            case 4:
                _anchuraWriter.text = "220";
                break;
            case 5:
                _anchuraWriter.text = "280";
                break;
            case 6:
                _anchuraWriter.text = "360";
                break;
            case 7:
                _anchuraWriter.text = "400";
                break;
            case 8:
                _anchuraWriter.text = "460";
                break;
        }

    }
}
