using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildRuntime01 : MonoBehaviour
{
    /*SLIDERS-BASED (HEIGHT AND WIDTH) SYSTEM TO CREATE THE INITIAL FURNITURE*/


    
    public Transform[] _racks;  


    public int _repeatRight;
    public int _repeatUp;


    public Slider _anchuraSlider;
    public Slider _alturaSlider;

    public Transform[] _pendings;


    // Start is called before the first frame update
    void Start()
    {
        //CreateFurtniture();
       
    }

    //CROSSED PRODUCT OF THE HORIZONTAL SLIDER AND THE VERTICAL SLIDER IN CASES
    public void CreateFurtniture()
    {
        CheckForPrevious();


            for (int h = 0; h < _anchuraSlider.value; h++)
            {

                switch (h)
                {
                     case 0:
                        Instantiate(_racks[0], new Vector3(h, 0.585f, 0), Quaternion.Euler(0, -180, 0));

                        for (int v = 0; v < _alturaSlider.value; v++)
                            {
                                switch (v)
                                {
                                        case 0:
                                            break;
                                        case 1:
                                        Instantiate(_racks[1], new Vector3(0, 2.1522f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 2:
                                        Instantiate(_racks[2], new Vector3(0, 3.9583f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 3:
                                        Instantiate(_racks[3], new Vector3(0, 5.4387f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 4:
                                        Instantiate(_racks[1], new Vector3(0, 6.7045f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 5:
                                        Instantiate(_racks[2], new Vector3(0, 8.5106f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 6:
                                        Instantiate(_racks[3], new Vector3(0, 9.991f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        case 7:
                                        Instantiate(_racks[1], new Vector3(0, 11.257f, 0), Quaternion.Euler(0, -180, 0));
                                            break;
                                        default:
                                        //Instantiate(_racks[1], new Vector3(h, 2.5106f + (1.4231f * (v - 1) ), 0), Quaternion.identity);
                                            break;
                                }           
                            } 
                        break;

                     case 1:
                        Instantiate(_racks[4], new Vector3(1.4457f, 0.88028f, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[5], new Vector3(1.4457f, 2.1539f, 0), Quaternion.identity);
                                    break;
                                case 2:
                                    Instantiate(_racks[6], new Vector3(1.4457f, 3.9584f, 0), Quaternion.identity);
                                    break;
                                case 3:
                                    Instantiate(_racks[7], new Vector3(1.4608f, 5.4627f, 0), Quaternion.identity);
                                    break;
                                case 4:
                                    Instantiate(_racks[5], new Vector3(1.4457f, 6.7063f, 0), Quaternion.identity);
                                    break;
                                case 5:
                                    Instantiate(_racks[6], new Vector3(1.4457f, 8.500401f, 0), Quaternion.identity);
                                    break;
                                case 6:
                                    Instantiate(_racks[7], new Vector3(1.4608f, 10.0089f, 0), Quaternion.identity);
                                    break;
                                case 7:
                                    Instantiate(_racks[5], new Vector3(1.4457f, 11.259f, 0), Quaternion.identity);
                                    break;
                                default:
                                    //Instantiate(_racks[3], new Vector3(2.4064f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;

                     case 2:
                        Instantiate(_racks[8], new Vector3(3.5517f, 0.64402f, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[9], new Vector3(3.5365f, 1.9269f, 0), Quaternion.identity);
                                    break;
                                case 2:
                                    Instantiate(_racks[10], new Vector3(3.5365f, 3.9584f, 0), Quaternion.identity);
                                    break;
                                case 3:
                                    Instantiate(_racks[11], new Vector3(3.5365f, 5.4388f, 0), Quaternion.identity);
                                    break;
                                case 4:
                                    Instantiate(_racks[9], new Vector3(3.5365f, 6.4761f, 0), Quaternion.identity);
                                    break;
                                case 5:
                                    Instantiate(_racks[10], new Vector3(3.5365f, 8.5076f, 0), Quaternion.identity);
                                    break;
                               case 6:
                                    Instantiate(_racks[11], new Vector3(3.5365f, 9.988f, 0), Quaternion.identity);
                                    break;
                               case 7:
                                    Instantiate(_racks[9], new Vector3(3.5365f, 11.028f, 0), Quaternion.identity);
                                    break;
                                default:
                                    //Instantiate(_racks[1], new Vector3(3.8529f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;

                     case 3:
                        Instantiate(_racks[0], new Vector3(5.3433f, 0.585f, 0), Quaternion.Euler(0, 0, 0));

                        for (int v = 0; v < _alturaSlider.value; v++)
                            {
                                switch (v)
                                {
                                        case 0:
                                            break;
                                        case 1:
                                        Instantiate(_racks[1], new Vector3(5.3433f, 2.1522f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 2:
                                        Instantiate(_racks[2], new Vector3(5.3433f, 3.9583f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 3:
                                        Instantiate(_racks[3], new Vector3(5.3433f, 5.4387f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 4:
                                        Instantiate(_racks[1], new Vector3(5.3433f, 6.7045f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 5:
                                        Instantiate(_racks[2], new Vector3(5.3433f, 8.5106f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 6:
                                        Instantiate(_racks[3], new Vector3(5.3433f, 9.991f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 7:
                                        Instantiate(_racks[1], new Vector3(5.3433f, 11.257f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        default:
                                        //Instantiate(_racks[1], new Vector3(h, 2.5106f + (1.4231f * (v - 1) ), 0), Quaternion.identity);
                                            break;
                                }           
                            } 

                    break;
                     case 4:
                        Instantiate(_racks[4], new Vector3(6.8636f, 0.88028f, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[5], new Vector3(6.8636f, 2.1539f, 0), Quaternion.identity);
                                    break;
                                case 2:
                                    Instantiate(_racks[6], new Vector3(6.8636f, 3.9584f, 0), Quaternion.identity);
                                    break;
                                case 3:
                                    Instantiate(_racks[7], new Vector3(6.8787f, 5.4627f, 0), Quaternion.identity);
                                    break;
                                case 4:
                                    Instantiate(_racks[5], new Vector3(6.8636f, 6.7063f, 0), Quaternion.identity);
                                    break;
                                case 5:
                                    Instantiate(_racks[6], new Vector3(6.8636f, 8.500401f, 0), Quaternion.identity);
                                    break;
                                case 6:
                                    Instantiate(_racks[7], new Vector3(6.8787f, 10.0089f, 0), Quaternion.identity);
                                    break;
                                case 7:
                                    Instantiate(_racks[5], new Vector3(6.8636f, 11.259f, 0), Quaternion.identity);
                                    break;
                                default:
                                    //Instantiate(_racks[3], new Vector3(2.4064f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 5:
                       Instantiate(_racks[8], new Vector3(8.97f, 0.64402f, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[9], new Vector3(8.97f, 1.9269f, 0), Quaternion.identity);
                                    break;
                                case 2:
                                    Instantiate(_racks[10], new Vector3(8.97f, 3.9584f, 0), Quaternion.identity);
                                    break;
                                case 3:
                                    Instantiate(_racks[11], new Vector3(8.97f, 5.4388f, 0), Quaternion.identity);
                                    break;
                                case 4:
                                    Instantiate(_racks[9], new Vector3(8.97f, 6.4761f, 0), Quaternion.identity);
                                    break;
                                case 5:
                                    Instantiate(_racks[10], new Vector3(8.97f, 8.5076f, 0), Quaternion.identity);
                                    break;
                               case 6:
                                    Instantiate(_racks[11], new Vector3(8.97f, 9.988f, 0), Quaternion.identity);
                                    break;
                               case 7:
                                    Instantiate(_racks[9], new Vector3(8.97f, 11.028f, 0), Quaternion.identity);
                                    break;
                                default:
                                    //Instantiate(_racks[1], new Vector3(3.8529f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 6:
                        Instantiate(_racks[0], new Vector3(10.762f, 0.585f, 0), Quaternion.Euler(0, 0, 0));

                        for (int v = 0; v < _alturaSlider.value; v++)
                            {
                                switch (v)
                                {
                                        case 0:
                                            break;
                                        case 1:
                                        Instantiate(_racks[1], new Vector3(10.762f, 2.1522f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 2:
                                        Instantiate(_racks[2], new Vector3(10.762f, 3.9583f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 3:
                                        Instantiate(_racks[3], new Vector3(10.762f, 5.4387f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 4:
                                        Instantiate(_racks[1], new Vector3(10.762f, 6.7045f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 5:
                                        Instantiate(_racks[2], new Vector3(10.762f, 8.5106f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 6:
                                        Instantiate(_racks[3], new Vector3(10.762f, 9.991f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        case 7:
                                        Instantiate(_racks[1], new Vector3(10.762f, 11.257f, 0), Quaternion.Euler(0, 0, 0));
                                            break;
                                        default:
                                        //Instantiate(_racks[1], new Vector3(h, 2.5106f + (1.4231f * (v - 1) ), 0), Quaternion.identity);
                                            break;
                                }           
                            } 
                    break;
                     case 7:
                    Instantiate(_racks[4], new Vector3(12.282f, 0.88028f, 0), Quaternion.identity);
                    for (int v = 0; v < _alturaSlider.value; v++)
                    {
                        switch (v)
                        {
                            case 0:
                                break;
                            case 1:
                                Instantiate(_racks[5], new Vector3(12.282f, 2.1539f, 0), Quaternion.identity);
                                break;
                            case 2:
                                Instantiate(_racks[6], new Vector3(12.282f, 3.9584f, 0), Quaternion.identity);
                                break;
                            case 3:
                                Instantiate(_racks[7], new Vector3(12.29697f, 5.4627f, 0), Quaternion.identity);
                                break;
                            case 4:
                                Instantiate(_racks[5], new Vector3(12.282f, 6.7063f, 0), Quaternion.identity);
                                break;
                            case 5:
                                Instantiate(_racks[6], new Vector3(12.282f, 8.500401f, 0), Quaternion.identity);
                                break;
                            case 6:
                                Instantiate(_racks[7], new Vector3(12.29697f, 10.0089f, 0), Quaternion.identity);
                                break;
                            case 7:
                                Instantiate(_racks[5], new Vector3(12.282f, 11.259f, 0), Quaternion.identity);
                                break;
                            default:
                                //Instantiate(_racks[3], new Vector3(2.4064f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                break;
                        }
                    }
                    break; 

                    

                }

                //var mainPosition = Instantiate(_mobelPrefab, new Vector3(h , v, 0), Quaternion.identity);
                //mainPosition.transform.parent = gameObject.transform;

            }

        

        

    }


    // IF USING AGAIN THE SLIDERS CHECK TO NOT HAVE REPEATED FURNITURE
    void CheckForPrevious()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    void StackToInstantiate(Transform _stackToSpawn, int anchura, int altura, float separation)
    {
        Instantiate(_stackToSpawn, new Vector3(anchura + (anchura * separation), altura, 0), Quaternion.identity);
    }


}
