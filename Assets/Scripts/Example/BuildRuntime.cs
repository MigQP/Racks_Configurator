using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildRuntime : MonoBehaviour
{
    /*DEPRECATED*/

    /*SLIDERS-BASED (HEIGHT AND WIDTH) SYSTEM TO CREATE THE INITIAL FURNITURE*/

    public Transform _mediumModule;
    public Transform _largeModule;
    public Transform _littleModule;

    public Transform _mobelPrefab;
    public Transform _newPrefab;

    public Transform[] _racks;  


    public int _repeatRight;
    public int _repeatUp;


    public Slider _anchuraSlider;
    public Slider _alturaSlider;


    private float _stackSeparation = .5f;

    // Start is called before the first frame update
    void Start()
    {
        //CreateFurtniture();
       
    }


    public void CreateFurtniture()
    {
        CheckForPrevious();


            for (int h = 0; h < _anchuraSlider.value; h++)
            {

                switch (h)
                {
                     case 0:
                        Instantiate(_racks[0], new Vector3(h, 0, 0), Quaternion.identity);

                        for (int v = 0; v < _alturaSlider.value; v++)
                            {
                                switch (v)
                                {
                                        case 0:
                                            break;
                                        case 1:
                                        Instantiate(_racks[1], new Vector3(h, 2.5106f, 0), Quaternion.identity);
                                            break;
                                        default:
                                        Instantiate(_racks[1], new Vector3(h, 2.5106f + (1.4231f * (v - 1) ), 0), Quaternion.identity);
                                            break;
                                }           
                            } 
                        break;

                     case 1:
                        Instantiate(_racks[2], new Vector3(2.4064f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[3], new Vector3(2.4064f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[3], new Vector3(2.4064f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;

                     case 2:
                        Instantiate(_racks[0], new Vector3(3.8529f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[1], new Vector3(3.8529f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[1], new Vector3(3.8529f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;

                     case 3:
                        Instantiate(_racks[2], new Vector3(6.2593f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[3], new Vector3(6.2593f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[3], new Vector3(6.2593f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 4:
                        Instantiate(_racks[0], new Vector3(7.7058f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[1], new Vector3(7.7058f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[1], new Vector3(7.7058f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 5:
                        Instantiate(_racks[2], new Vector3(10.1122f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[3], new Vector3(10.1122f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[3], new Vector3(10.1122f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 6:
                        Instantiate(_racks[0], new Vector3(11.5587f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[1], new Vector3(11.5587f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[1], new Vector3(11.5587f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break;
                     case 7:
                        Instantiate(_racks[2], new Vector3(13.9651f, 0, 0), Quaternion.identity);
                        for (int v = 0; v < _alturaSlider.value; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Instantiate(_racks[3], new Vector3(13.9651f, 2.5106f, 0), Quaternion.identity);
                                    break;
                                default:
                                    Instantiate(_racks[3], new Vector3(13.9651f, 2.5106f + (1.4231f * (v - 1)), 0), Quaternion.identity);
                                    break;
                            }
                        }
                    break; 

                    
                    /*     //INSTANCIADO DE 3
                      case 0:
                        StackToInstantiate(_mediumModule, h, v, _stackSeparation);
                        break;

                    case 1:
                        StackToInstantiate(_littleModule, h, v, _stackSeparation);
                        break;

                    case 2:
                        StackToInstantiate(_largeModule, h, v, _secondStackSeparation);
                        break;

                    case 3:
                        StackToInstantiate(_mediumModule, h, v, _thirdStackSeparation);
                        break;
                    case 4:
                        StackToInstantiate(_littleModule, h, v, _fourthSeparation);
                        break;
                    case 5:
                        StackToInstantiate(_largeModule, h, v, _fifthSeparation);
                        break;
                    case 6:
                        StackToInstantiate(_mediumModule, h, v, _thirdStackSeparation);
                        break;
                    case 7:
                        StackToInstantiate(_littleModule, h, v, _sixthSeparation);
                        break;
                    */
                }

                //var mainPosition = Instantiate(_mobelPrefab, new Vector3(h , v, 0), Quaternion.identity);
                //mainPosition.transform.parent = gameObject.transform;

            }

        

        

    }

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


    void createR ()
    {
        for (int v = 0; v < _alturaSlider.value; v++)
        {
            for (int h = 0; h < _anchuraSlider.value; h++)
            {

                switch (h)
                {
                    case 0:
                        Instantiate(_mobelPrefab, new Vector3(h, v, 0), Quaternion.identity);
                        break;

                    case 1:
                        Instantiate(_newPrefab, new Vector3(2.4064f, v, 0), Quaternion.identity);
                        break;

                    case 2:
                        Instantiate(_newPrefab, new Vector3(3.8529f, v, 0), Quaternion.identity);
                        break;

                    case 3:
                        StackToInstantiate(_newPrefab, h, v, _stackSeparation);
                        break;
                    case 4:
                        StackToInstantiate(_mobelPrefab, h, v, _stackSeparation);
                        break;
                    case 5:
                        StackToInstantiate(_newPrefab, h, v, _stackSeparation);
                        break;
                    case 6:
                        StackToInstantiate(_mobelPrefab, h, v, _stackSeparation);
                        break;
                    case 7:
                        StackToInstantiate(_newPrefab, h, v, _stackSeparation);
                        break;


                        /*     //INSTANCIADO DE 3
                          case 0:
                            StackToInstantiate(_mediumModule, h, v, _stackSeparation);
                            break;

                        case 1:
                            StackToInstantiate(_littleModule, h, v, _stackSeparation);
                            break;

                        case 2:
                            StackToInstantiate(_largeModule, h, v, _secondStackSeparation);
                            break;

                        case 3:
                            StackToInstantiate(_mediumModule, h, v, _thirdStackSeparation);
                            break;
                        case 4:
                            StackToInstantiate(_littleModule, h, v, _fourthSeparation);
                            break;
                        case 5:
                            StackToInstantiate(_largeModule, h, v, _fifthSeparation);
                            break;
                        case 6:
                            StackToInstantiate(_mediumModule, h, v, _thirdStackSeparation);
                            break;
                        case 7:
                            StackToInstantiate(_littleModule, h, v, _sixthSeparation);
                            break;
                        */
                }

                //var mainPosition = Instantiate(_mobelPrefab, new Vector3(h , v, 0), Quaternion.identity);
                //mainPosition.transform.parent = gameObject.transform;

            }

        }
    }
}
