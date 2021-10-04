using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class TotalHeight : MonoBehaviour
{

    public List<GameObject> verticalLane = new List<GameObject>();
    public GameObject _highestObj;

    public List<GameObject> horizontalLane = new List<GameObject>();
    public GameObject _widestObj;

    public GameObject _leastXObj;

    public Canvas heightCanvas;
    public Canvas widthCanvas;
    public Toggle _showMeasures;

    public Text heightTxt;

    public Text widthTxt;

    public float _totalHeightVal;

    public float _totalWidthVal;


    public GameObject _totalHeightObj;

    public float _cubeHeight;

    public float _cubeWidth;

    private MeasuresManager _measureManager;
    // Start is called before the first frame update
    void Start()
    {
        _measureManager = FindObjectOfType<MeasuresManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //_highestObj = _measureManager._measureObjs.OrderByDescending(_highestObj => _highestObj.transform.position.y).First();



        if (!_showMeasures.isOn)
            return;

        if (_measureManager._measureObjs.Length > 0)
        {
            _totalHeightObj.SetActive(true);
        }

        else
        {
            _totalHeightObj.SetActive(false);
        }

        if (!_totalHeightObj.active)
            return;

        _highestObj = _measureManager._measureObjs.OrderByDescending(_highestObj => _highestObj.transform.position.y).First();
        _widestObj = _measureManager._measureObjs.OrderByDescending(_widestObj => _widestObj.transform.position.x).First();
        _leastXObj = _measureManager._measureObjs.OrderByDescending(_widestObj => _widestObj.transform.position.x).Last();
        GetCubeHeight();
        GetHeight();
        TextHeight();

        GetCubeWidth();
        GetWidth();
        TextWidth();


    }

    public void GetHeight ()
    {
        verticalLane.Clear();
        _totalHeightVal = 0;

        /*
        for (int i = 0; i < _measureManager._measureObjs.Length; i++)
        {
            if (_measureManager._measureObjs[i].transform.position.x >= _highestObj.transform.position.x -.02f  && _measureManager._measureObjs[i].transform.position.x <= _highestObj.transform.position.x + .02f)
            {
                verticalLane.Add(_measureManager._measureObjs[i]);

            }
        }
        */

        verticalLane.Add(_highestObj);
        if (_highestObj.GetComponentInChildren<LanePoints01>() != null)
        {
            for (int i = 0; i < _highestObj.GetComponentInChildren<LanePoints01>().downRacks.Count; i++)
            {
                verticalLane.Add(_highestObj.GetComponentInChildren<LanePoints01>().downRacks[i]);
            }
        }



        for (int h = 0; h < verticalLane.Count; h++)
        {
            _totalHeightVal += verticalLane[h].GetComponent<ConcurrentSpawn>().Height;
        }

        



        //_cubeHeight = Vector3.Distance(_totalHeightObj.transform.position, _highestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].transform.position);
        //_totalHeightObj.transform.localScale = new Vector3(1, _cubeHeight, 1);

        RectTransform rt = heightCanvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(_cubeHeight * 430, 444);
    }

    void TextHeight ()
    {
        heightTxt.text = _totalHeightVal.ToString() + " cm";
    }

    void GetCubeHeight ()
    {
        _totalHeightObj.transform.position = new Vector3(_leastXObj.transform.position.x - 1.8f, _totalHeightObj.transform.position.y, _totalHeightObj.transform.position.z); 


        var from = _totalHeightObj.transform.position;
        //var to = _highestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].transform.position;
        var to = _highestObj.GetComponent<ConcurrentSpawn>()._topPoint.position;


        _cubeHeight = Vector3.Distance(from, new Vector3(from.x, to.y, from.z));
    }
    
    public void GetWidth()
    {
        horizontalLane.Clear();
        _totalWidthVal = 0;

        for (int i = 0; i < _measureManager._measureObjs.Length; i++)
        {
            if (_measureManager._measureObjs[i].GetComponent<ConcurrentSpawn>().Height == 35)
            {
                horizontalLane.Add(_measureManager._measureObjs[i]);

            }
        }


        for (int h = 0; h < horizontalLane.Count; h++)
        {
            _totalWidthVal += horizontalLane[h].GetComponent<ConcurrentSpawn>().Width;
        }





        //_cubeHeight = Vector3.Distance(_totalHeightObj.transform.position, _highestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[0].transform.position);
        //_totalHeightObj.transform.localScale = new Vector3(1, _cubeHeight, 1);

        RectTransform rt = widthCanvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(_cubeWidth * 431.935131787F, 444);
    }
    void TextWidth()
    {
        float roundedWidth = Mathf.Round(_totalWidthVal / 10) * 10;
        widthTxt.text = roundedWidth.ToString() + " cm";
    }

    void GetCubeWidth()
    {
        var from = _totalHeightObj.transform.position;
        var to = _widestObj.transform.position;


        _cubeWidth = Vector3.Distance(from, new Vector3(to.x, from.y, from.z));
    }
}
