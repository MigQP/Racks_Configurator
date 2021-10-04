using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcurrentSpawn : MonoBehaviour
{
    /*MAIN SPAWN SYSTEM FOR INDIVIDUAL RACKS 
      FIRST BEING THE PREVIEW RACK AND WHEN CONFIRMED THE FINAL RACK IN ONE OF THREE POSITIONS (UP, LEFT OR RIGHT)*/

    public float Price;
    public float Width;
    public float Height;

    public float leftSeparation;

    public Transform _upStack;
    public Transform _sideStack;
    public Transform _leftSideStack;

    public Transform[] _pendings;
    public Transform[] _stacks;

    public GameObject[] _spawnPoints;

    public bool _canSpawn = false;


    private ExtrasManager _extrasManager;
    public GameObject _extraSpawn;

    private LanePoints01 _laneDetector;
    private UpLane _upLaneDetector;


    public Transform[] _otherPoints;

    public int firstObject;
    public int secondObject;
    public int thirdObject;
    public Transform _topPoint;

    // Start is called before the first frame update
    void Start()
    {
        _extrasManager = FindObjectOfType<ExtrasManager>();
        PriceManager._furnitureValue += Price;
        _laneDetector = GetComponentInChildren<LanePoints01>();
        CheckPreviousExtras();
        ErasePending();

        // CHECKS IF TT IS A BASE RACK
        if (_laneDetector != null)
            return;
            _upLaneDetector = GetComponentInChildren<UpLane>();
    }


    public void CreateStack (Transform _spawnPoint)
    {
        var mainPosition = Instantiate(_upStack, _spawnPoint.position, Quaternion.identity);
        mainPosition.transform.parent = gameObject.transform;
        //Instantiate(_upStack, _spawnPoint.position, Quaternion.identity);
    }

    public void CreateSideStack (Transform _sidePoint)
    {
        Instantiate(_sideStack, _sidePoint.position, Quaternion.identity);
    }


    //SISTEMA DE PENDINTE Y SPAWN


    // PREVIEW RACKS DEPENDING ON EACH WIDTH / HEIGHT
    public void CreatePendingStacks()
    {
        ErasePending();

        for (int i =0; i < _spawnPoints.Length; i++)
        {
            switch (i)
            {
                case 0:
                    //ORIGINAL
                    var mainPosition = Instantiate(_pendings[0], _spawnPoints[i].transform.position, transform.rotation);
                    mainPosition.transform.parent = gameObject.transform;
                   
                    break;
                case 1:
                    //ORIGINAL
                    //var mainPosition2 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.identity);
                    //mainPosition2.transform.parent = gameObject.transform;
                    if (_laneDetector != null)
                    {
                        _laneDetector.CreateRightPendingLane();

                        if (Width == _laneDetector._rightWidth)
                        {
                            switch(Width)
                            {
                                case 25:
                                    var mainPosition1 = Instantiate(_pendings[0], _spawnPoints[i].transform.position, Quaternion.identity);
                                    mainPosition1.transform.parent = gameObject.transform;
                                    break;
                                case 40:
                                    if (transform.rotation.y == -1)
                                    {
                                        var mainPosition4 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                                        mainPosition4.transform.parent = gameObject.transform;

                                    }
                                    else
                                    {
                                        var mainPosition4 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        mainPosition4.transform.parent = gameObject.transform;
                                    }
                                    break;
                                case 60:
                                    var mainPosition2 = Instantiate(_pendings[0], _spawnPoints[i].transform.position, Quaternion.identity);
                                    mainPosition2.transform.parent = gameObject.transform;
                                    break;
                                case 61:
                                    var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.identity);
                                    mainPosition3.transform.parent = gameObject.transform;
                                    break;
                                case 80:
                                    if (transform.rotation.y == 0)
                                    {
                                        var mainPosition4 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                                        mainPosition4.transform.parent = gameObject.transform;

                                    }
                                    else
                                    {
                                        var mainPosition4 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        mainPosition4.transform.parent = gameObject.transform;
                                    }
                                    break;

                            }
                        }

                        else
                        {
                            switch (Width)
                            {
                                case 25:
                                    var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.identity);
                                    mainPosition1.transform.parent = gameObject.transform;
                                    break;
;
                                case 60:

                                    // ANTERIOR CORRECCION
                                    //var mainPosition2 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.identity);
                                    //mainPosition2.transform.parent = gameObject.transform;
                                    break;
                                case 61:
                                    
                                    break;

                            }

                            switch (_laneDetector._rightWidth)
                            {
                                case 40:
                                    switch (Height)
                                    {
                                        case 25:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[3], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition4.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[3], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
                                                    mainPosition5.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[3], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
                                                    mainPosition6.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            //var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[11], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition4.transform.parent = gameObject.transform;
                                            break;
                                        case 45:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition5.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition7 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
                                                    mainPosition7.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition8 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
                                                    mainPosition8.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            //var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition5.transform.parent = gameObject.transform;
                                            break;
                                        case 60:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[2], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition6.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition7 = Instantiate(_laneDetector.stacksManager._pendings[2], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                    mainPosition7.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition8 = Instantiate(_laneDetector.stacksManager._pendings[2], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                    mainPosition8.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            //var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[10], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition6.transform.parent = gameObject.transform;
                                            break;
                                    }
                                    break;
                                case 61:
                                    switch (Height)
                                    {
                                        case 25:
                                            var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[7], _otherPoints[0].position, Quaternion.identity);
                                            mainPosition1.transform.parent = gameObject.transform;
                                            break;
                                        case 45:
                                            var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[0].position, Quaternion.identity);
                                            mainPosition2.transform.parent = gameObject.transform;
                                            break;
                                        case 60:
                                            var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[6], _otherPoints[0].position, Quaternion.identity);
                                            mainPosition3.transform.parent = gameObject.transform;
                                            break;

                                    }
                                    //var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[0].position, Quaternion.identity);
                                    //mainPosition2.transform.parent = gameObject.transform;
                                    break;
                                case 80:
                                    switch (Height)
                                    {
                                        case 25:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[11], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition4.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[11], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y -360, transform.rotation.z));
                                                    mainPosition5.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    break;
                                            }
                                            //var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[11], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition4.transform.parent = gameObject.transform;
                                            break;
                                        case 45:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition5.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition7 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
                                                    mainPosition7.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    break;
                                            }
                                            //var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition5.transform.parent = gameObject.transform;
                                            break;
                                        case 60:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[10], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                    mainPosition6.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition7 = Instantiate(_laneDetector.stacksManager._pendings[10], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                                                    mainPosition7.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    break;
                                            }
                                            //var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[10], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                            //mainPosition6.transform.parent = gameObject.transform;
                                            break;
                                    }
                                    //var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[2].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                    //mainPosition5.transform.parent = gameObject.transform;
                                    break;
                            }


                        }
                    }
                    else
                    {
                        if (transform.rotation.y == 0)
                        {
                           var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 0, transform.rotation.z));
                           mainPosition3.transform.parent = gameObject.transform;
                        }

                        else
                        {
                            var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                            mainPosition3.transform.parent = gameObject.transform;
                        }

                    }
                    //_laneDetector.CreateRightPendingLane();
                    break;
                case 2:
                    //ORIGINAL
                    //var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.identity);
                    //mainPosition3.transform.parent = gameObject.transform;
                    //CORREGIR EN LA MAÑANA AQUI
                    if (_laneDetector != null)
                    {
                       _laneDetector.CreateLefttPendingLane();

                        if (Width == _laneDetector._leftWidth)
                        {
                            switch (Width)
                            {

                                case 25:
                                    var mainPosition4 = Instantiate(_pendings[0], new Vector3(_spawnPoints[i].transform.position.x - leftSeparation, _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                                    mainPosition4.transform.parent = gameObject.transform;
                                    break;
                                case 40:
                                    var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, transform.rotation);
                                    mainPosition3.transform.parent = gameObject.transform;
                                    break;
                                case 60:
                                    var mainPosition5 = Instantiate(_pendings[0], new Vector3(_spawnPoints[i].transform.position.x -leftSeparation, _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                                    mainPosition5.transform.parent = gameObject.transform;
                                    break;
                                case 61:
                                    var mainPosition6 = Instantiate(_pendings[1], new Vector3(_spawnPoints[i].transform.position.x - leftSeparation, _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                                    mainPosition6.transform.parent = gameObject.transform;
                                    break;
                                case 80:
                                    if (transform.rotation.y == 0)
                                    {
                                        var mainPosition7 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                                        mainPosition7.transform.parent = gameObject.transform;

                                    }
                                    else
                                    {
                                        var mainPosition8 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                        mainPosition8.transform.parent = gameObject.transform;
                                    }
                                    break;
                            }
                            //var mainPosition3 = Instantiate(_pendings[0], _spawnPoints[i].transform.position, Quaternion.identity);
                            //mainPosition3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            switch (Width)
                            {
                                case 25:
                                    var mainPosition3 = Instantiate(_pendings[1], new Vector3 (_spawnPoints[i].transform.position.x , _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                                    mainPosition3.transform.parent = gameObject.transform;
                                    break;
                                case 40:
                                    break;
                                case 60:
                                    var mainPosition4 = Instantiate(_pendings[1], new Vector3 (_spawnPoints[i].transform.position.x , _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                                    mainPosition4.transform.parent = gameObject.transform;
                                    break;
                                case 61:

                                    break;

                            }

                            switch (_laneDetector._leftWidth)
                            {
                                case 40:
                                    switch (Height)
                                    {
                                        case 25:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[3], _otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                mainPosition2.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[3], _otherPoints[1].transform.position, transform.rotation);
                                                mainPosition4.transform.parent = gameObject.transform;
                                            }
                                            break;
                                        case 45:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                mainPosition2.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[1].transform.position, transform.rotation);
                                                mainPosition4.transform.parent = gameObject.transform;
                                            }
                                            //var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[1], _otherPoints[1].position, Quaternion.identity);
                                            //mainPosition3.transform.parent = gameObject.transform;
                                            break;
                                        case 60:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[2], _otherPoints[1].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                mainPosition2.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[2], _otherPoints[1].transform.position, transform.rotation);
                                                mainPosition4.transform.parent = gameObject.transform;
                                            }
                                            break;
                                    }
                                    break;
                                case 61:
                                    switch (Height)
                                    {
                                        case 25:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[7], _otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 540, transform.rotation.z));
                                                mainPosition3.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[7], _otherPoints[1].position, Quaternion.identity);
                                                mainPosition3.transform.parent = gameObject.transform;
                                            }
                                            //var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[7], _otherPoints[1].position, Quaternion.identity);
                                            //mainPosition3.transform.parent = gameObject.transform;
                                            break;
                                        case 45:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                mainPosition4.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[1].position, Quaternion.identity);
                                                mainPosition4.transform.parent = gameObject.transform;
                                            }
                                            //var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[1].position, Quaternion.identity);
                                            //mainPosition4.transform.parent = gameObject.transform;
                                            break;
                                        case 60:
                                            if (transform.rotation.y == 0)
                                            {
                                                var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[6], _otherPoints[1].position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                                                mainPosition6.transform.parent = gameObject.transform;
                                            }
                                            else
                                            {
                                                var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[6], _otherPoints[1].position, Quaternion.identity);
                                                mainPosition6.transform.parent = gameObject.transform;
                                            }
                                            //var mainPosition6 = Instantiate(_laneDetector.stacksManager._pendings[6], _otherPoints[1].position, Quaternion.identity);
                                            //mainPosition6.transform.parent = gameObject.transform;
                                            break;
                                    }
                                    //var mainPosition4 = Instantiate(_laneDetector.stacksManager._pendings[5], _otherPoints[1].position, Quaternion.identity);
                                    //mainPosition4.transform.parent = gameObject.transform;
                                    break;
                                case 80:

                                    var mainPosition5 = Instantiate(_laneDetector.stacksManager._pendings[9], _otherPoints[1].position, Quaternion.identity);
                                    mainPosition5.transform.parent = gameObject.transform;
                                    break;
                            }
                            //var mainPosition3 = Instantiate(_pendings[1], new Vector3 (_spawnPoints[i].transform.position.x - leftSeparation, _spawnPoints[i].transform.position.y, _spawnPoints[i].transform.position.z), Quaternion.identity);
                            //mainPosition3.transform.parent = gameObject.transform;

                        }
                    }
                    else
                    {
                        if (transform.rotation.y == 0)
                        {
                            var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                            mainPosition3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, transform.rotation);
                            mainPosition3.transform.parent = gameObject.transform;
                        }

                        //var mainPosition3 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, transform.rotation);
                        //mainPosition3.transform.parent = gameObject.transform;
                    }
                    //_laneDetector.CreateLefttPendingLane();
                    break;
            }
        }

        //Instantiate(_upStack, _spawnPoint.position, Quaternion.identity);
    }

    public void CheckSpawn ()
    {

        _canSpawn = !_canSpawn;
        _extrasManager.ActualRack(_extraSpawn);
    }

    public void ErasePending ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Pending");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }

    public void CreateUpRack(Transform _spawnPoint)
    {
        //Instantiate(_stacks[0], _spawnPoint.position, Quaternion.identity);
        StartCoroutine(WaitUpRack(_spawnPoint));
    }

    IEnumerator WaitUpRack (Transform _originPoint)
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(_stacks[0], _originPoint.position, transform.rotation);
    }

    public void CreateSideRack(Transform _spawnPoint)
    {
        //Instantiate(_stacks[0], _spawnPoint.position, Quaternion.identity);
        StartCoroutine(WaitSideRack(_spawnPoint));
    }

    IEnumerator WaitSideRack(Transform _originPoint)
    {
        yield return new WaitForSeconds(.1f);
        //ORIGINAL
        //Instantiate(_stacks[1], _originPoint.position, Quaternion.identity);
        //PENDIENTE BASE DERECHO
        if (_upLaneDetector != null)
        {


            if (Width == _upLaneDetector.setWidth)
            {
               Instantiate(_stacks[1], _spawnPoints[1].transform.position, _spawnPoints[1].transform.rotation);

            }

            else
            {
                switch (_upLaneDetector.setWidth)
                {
                    case 40:
                        Instantiate(_stacks[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                        break;
                    case 61:
                        switch (Width)
                        {
                            case 40:
                                Instantiate(_stacks[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                break;
                            case 61:
                                Instantiate(_stacks[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                break;
                            case 80:
                                Instantiate(_stacks[secondObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                break;
                        }
                        //Instantiate(_stacks[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                        break;
                    case 80:
                        Instantiate(_stacks[thirdObject], _otherPoints[2].transform.position, _otherPoints[0].transform.rotation);
                        break;
                }
            }

        }
        //var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
        //mainPosition1.transform.parent = gameObject.transform;

        //Debug.Log(_laneDetector.lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width);
    }

    public void CreateLeftSideRack(Transform _spawnPoint)
    {
        //Instantiate(_stacks[0], _spawnPoint.position, Quaternion.identity);
        StartCoroutine(WaitLeftSideRack(_spawnPoint));
    }

    IEnumerator WaitLeftSideRack(Transform _originPoint)
    {
        yield return new WaitForSeconds(.1f);
        ///ORIGINAL
        //Instantiate(_stacks[1], _originPoint.position, Quaternion.identity);

        //PENDIENTE BASE IZQUIERDO
        if (_upLaneDetector != null)
        {


            if (Width == _upLaneDetector.setWidth)
            {
                Instantiate(_stacks[1], _spawnPoints[2].transform.position, _spawnPoints[2].transform.rotation);

            }

            else
            {
                switch (_upLaneDetector.setWidth)
                {
                    case 40:
                        Instantiate(_stacks[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);

                        break;
                    case 61:
                        switch (Width)
                        {
                            case 40:
                                Instantiate(_stacks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                break;
                            case 61:
                                Instantiate(_stacks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                break;
                            case 80:
                                Instantiate(_stacks[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                break;
                        }
                        //Instantiate(_stacks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);

                        break;
                    case 80:
                        Instantiate(_stacks[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);

                        break;
                }
            }

        }

        //var mainPosition2 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
        //mainPosition2.transform.parent = gameObject.transform;
        //Debug.Log(_laneDetector.lowestObj.GetComponent<ConcurrentSpawn>()._spawnPoints[2].GetComponent<CheckBuild>()._module.GetComponent<ConcurrentSpawn>().Width);
    }

    public void TurnOffButtons(GameObject _spawnButtons)
    {
        StartCoroutine(OffButtons(_spawnButtons));
    }

    IEnumerator OffButtons(GameObject _spawnButtons)
    {
        yield return new WaitForSeconds(.4f);

        _spawnButtons.SetActive(false);
    }

    public void DestroyItself ()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        PriceManager._furnitureValue -= Price;
    }

    public void CheckPreviousExtras()
    {
        if (_extraSpawn.transform.childCount > 0)
        {
            foreach (Transform child in _extraSpawn.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void NewPendingStacks()
    {


        if (_laneDetector != null)
        {

            _laneDetector.SetLowest();
            
        }
        //_laneDetector.SetLowest();
        ErasePending();
        


        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (_spawnPoints[0].GetComponent<CheckBuild>()._module == null)
                    {


                        var mainPosition = Instantiate(_pendings[0], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                        mainPosition.transform.parent = gameObject.transform;
                    }

                    break;
                case 1:
                    if (_spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                    {

                        if (_laneDetector != null)
                        {
                            if (Width == _laneDetector._rightWidth)
                            {
                                var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                mainPosition1.transform.parent = gameObject.transform;
                            }

                            else
                            {
                                switch (_laneDetector._rightWidth)
                                {
                                    case 40:
                                        switch (Width)
                                        {
                                            case 40:
                                                var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                mainPosition1.transform.parent = gameObject.transform;
                                                break;
                                            case 61:
                                                var mainPosition02 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                mainPosition02.transform.parent = gameObject.transform;
                                                break;
                                            case 80:
                                                var mainPosition03 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                                mainPosition03.transform.parent = gameObject.transform;
                                                break;
                    
                                        }
                                        //var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                        //mainPosition1.transform.parent = gameObject.transform;
                                        break;
                                    case 61:
                                        var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                        mainPosition2.transform.parent = gameObject.transform;
                                        break;
                                    case 80:
                                        var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[thirdObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                        mainPosition3.transform.parent = gameObject.transform;
                                        break;
                                }
                            }
                        }

                        else
                        {
                            //PENDIENTE BASE DERECHO
                            if (_upLaneDetector != null)
                            {


                                if (Width == _upLaneDetector.setWidth)
                                {
                                    var mainPosition01 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                    mainPosition01.transform.parent = gameObject.transform;
                                }

                                else
                                {
                                    switch (_upLaneDetector.setWidth)
                                    {
                                        case 40:
                                            var mainPosition02 = Instantiate(_pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                            mainPosition02.transform.parent = gameObject.transform;
                                            break;
                                        case 61:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition003 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                    mainPosition003.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition004 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                    mainPosition004.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition005 = Instantiate(_pendings[secondObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                                    mainPosition005.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            //var mainPosition03 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                            //mainPosition03.transform.parent = gameObject.transform;
                                            break;
                                        case 80:
                                            var mainPosition04 = Instantiate(_pendings[thirdObject], _otherPoints[2].transform.position, _otherPoints[0].transform.rotation);
                                            mainPosition04.transform.parent = gameObject.transform;
                                            break;
                                    }
                                }

                            }
                            //var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                            //mainPosition1.transform.parent = gameObject.transform;

                        }



                    }

                    break;
                case 2:
                    if (_spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                    {
                        if (_laneDetector != null)
                        {
                            if (Width == _laneDetector._leftWidth)
                            {
                                var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                mainPosition1.transform.parent = gameObject.transform;
                            }

                            else
                            {
                                switch (_laneDetector._leftWidth)
                                {
                                    case 40:
                                        var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                        mainPosition1.transform.parent = gameObject.transform;
                                        break;
                                    case 61:
                                        switch (Width)
                                        {
                                            case 40:
                                                var mainPosition02 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                mainPosition02.transform.parent = gameObject.transform;
                                                break;
                                            case 61:
                                                var mainPosition03 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                mainPosition03.transform.parent = gameObject.transform;
                                                break;
                                            case 80:
                                                var mainPosition04 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                                mainPosition04.transform.parent = gameObject.transform;
                                                break;
                                        }
                                        
                                        //var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                        //mainPosition2.transform.parent = gameObject.transform;
                                        break;
                                    case 80:
                                        var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                        mainPosition3.transform.parent = gameObject.transform;
                                        break;
                                }
                            }
                        }

                        else
                        {
                            //PENDIENTE BASE IZQUIERDO
                            if (_upLaneDetector != null)
                            {


                                if (Width == _upLaneDetector.setWidth)
                                {
                                    var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                    mainPosition1.transform.parent = gameObject.transform;
                                }

                                else
                                {
                                    switch (_upLaneDetector.setWidth)
                                    {
                                        case 40:
                                            var mainPosition02 = Instantiate(_pendings[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                            mainPosition02.transform.parent = gameObject.transform;
                                            break;
                                        case 61:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition003 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                    mainPosition003.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition004 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                    mainPosition004.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition005 = Instantiate(_pendings[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                                    mainPosition005.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            //var mainPosition03 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                            //mainPosition03.transform.parent = gameObject.transform;
                                            break;
                                        case 80:
                                            var mainPosition04 = Instantiate(_pendings[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                            mainPosition04.transform.parent = gameObject.transform;
                                            break;
                                    }
                                }

                            }

                            //var mainPosition2 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                            //mainPosition2.transform.parent = gameObject.transform;

                        }



                    }

                    break;
            }
        }


    }

    public void NewPendingLanes()
    {
       

        if (_laneDetector != null)
        {
            _laneDetector.SetLowestLane();
            
            //_laneDetector.SetLowest();
        }
        //_laneDetector.SetLowest();
        //ErasePending();



        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (_spawnPoints[0].GetComponent<CheckBuild>()._module == null)
                    {


                        var mainPosition = Instantiate(_pendings[0], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                        mainPosition.transform.parent = gameObject.transform;
                    }

                    break;
                case 1:
                    if (_spawnPoints[1].GetComponent<CheckBuild>()._module == null)
                    {

                        if (_laneDetector != null)
                        {
                            if (Width == _laneDetector._rightWidth)
                            {
                                var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                mainPosition1.transform.parent = gameObject.transform;
                            }

                            else
                            {
                                switch (_laneDetector._rightWidth)
                                {
                                    case 40:
                                        switch (Width)
                                        {
                                            case 40:
                                                var mainPosition02 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                mainPosition02.transform.parent = gameObject.transform;
                                                break;
                                            case 61:
                                                var mainPosition03 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                mainPosition03.transform.parent = gameObject.transform;
                                                break;
                                            case 80:
                                                var mainPosition04 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                                mainPosition04.transform.parent = gameObject.transform;
                                                break;
                                        }

                                        //var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                        //mainPosition1.transform.parent = gameObject.transform;
                                        break;
                                    case 61:
                                        var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                        mainPosition2.transform.parent = gameObject.transform;
                                        break;
                                    case 80:
                                        var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[thirdObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                        mainPosition3.transform.parent = gameObject.transform;
                                        break;
                                }
                            }
                        }

                        else
                        {   
                            //PENDIENTE BASE DERECHO
                            if (_upLaneDetector != null)
                            {


                                if (Width == _upLaneDetector.setWidth)
                                {
                                    var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                    mainPosition1.transform.parent = gameObject.transform;
                                }

                                else
                                {
                                    switch (_upLaneDetector.setWidth)
                                    {
                                        case 40:
                                            var mainPosition02 = Instantiate(_pendings[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                            mainPosition02.transform.parent = gameObject.transform;
                                            break;
                                        case 61:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition003 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                    mainPosition003.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition004 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                                    mainPosition004.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition005 = Instantiate(_pendings[secondObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                                    mainPosition005.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            
                                            //var mainPosition03 = Instantiate(_pendings[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                            //mainPosition03.transform.parent = gameObject.transform;
                                            break;
                                        case 80:
                                            var mainPosition04 = Instantiate(_pendings[thirdObject], _otherPoints[2].transform.position, _otherPoints[0].transform.rotation);
                                            mainPosition04.transform.parent = gameObject.transform;
                                            break;
                                    }
                                }

                            }
                            //var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                            //mainPosition1.transform.parent = gameObject.transform;
                        }



                    }

                    break;
                case 2:
                    if (_spawnPoints[2].GetComponent<CheckBuild>()._module == null)
                    {
                        if (_laneDetector != null)
                        {
                            if (Width == _laneDetector._leftWidth)
                            {
                                var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                mainPosition1.transform.parent = gameObject.transform;
                            }

                            else
                            {
                                switch (_laneDetector._leftWidth)
                                {
                                    case 40:
                                        var mainPosition1 = Instantiate(_laneDetector.stacksManager._pendings[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                        mainPosition1.transform.parent = gameObject.transform;
                                        break;
                                    case 61:
                                        switch (Width)
                                        {
                                            case 40:
                                                var mainPosition02 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                mainPosition02.transform.parent = gameObject.transform;
                                                break;
                                            case 61:
                                                var mainPosition03 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                mainPosition03.transform.parent = gameObject.transform;
                                                break;
                                            case 80:
                                                var mainPosition04 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                                mainPosition04.transform.parent = gameObject.transform;
                                                break;
                                        }
                                        //var mainPosition2 = Instantiate(_laneDetector.stacksManager._pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                        //mainPosition2.transform.parent = gameObject.transform;
                                        break;
                                    case 80:
                                        var mainPosition3 = Instantiate(_laneDetector.stacksManager._pendings[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                        mainPosition3.transform.parent = gameObject.transform;
                                        break;
                                }
                            }
                        }

                        else
                        {
                            //PENDIENTE BASE IZQUIERDO
                            if (_upLaneDetector != null)
                            {


                                if (Width == _upLaneDetector.setWidth)
                                {
                                    var mainPosition1 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                                    mainPosition1.transform.parent = gameObject.transform;
                                }

                                else
                                {
                                    switch (_upLaneDetector.setWidth)
                                    {
                                        case 40:
                                            var mainPosition02 = Instantiate(_pendings[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                            mainPosition02.transform.parent = gameObject.transform;
                                            break;
                                        case 61:
                                            switch (Width)
                                            {
                                                case 40:
                                                    var mainPosition003 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                    mainPosition003.transform.parent = gameObject.transform;
                                                    break;
                                                case 61:
                                                    var mainPosition004 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                                    mainPosition004.transform.parent = gameObject.transform;
                                                    break;
                                                case 80:
                                                    var mainPosition005 = Instantiate(_pendings[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                                    mainPosition005.transform.parent = gameObject.transform;
                                                    break;
                                            }
                                            
                                            //var mainPosition03 = Instantiate(_pendings[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                            //mainPosition03.transform.parent = gameObject.transform;
                                            break;
                                        case 80:
                                            var mainPosition04 = Instantiate(_pendings[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                            mainPosition04.transform.parent = gameObject.transform;
                                            break;
                                    }
                                }

                            }

                            //var mainPosition2 = Instantiate(_pendings[1], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
                            //mainPosition2.transform.parent = gameObject.transform;
                        }



                    }

                    break;
            }
        }


    }

    public void CreateNewUpRack (Transform _spawnPoint)
    {
        StartCoroutine(WaitNewUpRack(_spawnPoint));
    }

    IEnumerator WaitNewUpRack (Transform _originPoint)
    {
        yield return new WaitForSeconds(.2f);

        Instantiate(_stacks[0], _originPoint.transform.position, _originPoint.transform.rotation);
    }

    public void CreateNewLeftRack (Transform _spawnPoint)
    {
        _spawnPoint = _spawnPoints[2].transform;
        StartCoroutine(WaitNewLeftRack(_spawnPoint));
    }

    IEnumerator WaitNewLeftRack (Transform _originPoint)
    {
        yield return new WaitForSeconds(.2f);


        if (_laneDetector != null)
        {
            if (Width == _laneDetector._leftWidth)
            {
                Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
            }

            else
            {
                switch (_laneDetector._leftWidth)
                {
                    case 40:
                        Instantiate(_laneDetector.stacksManager._racks[firstObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                        break;
                    case 61:
                        switch(Width)
                        {
                            case 40:
                                Instantiate(_laneDetector.stacksManager._racks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                break;
                            case 61:
                                Instantiate(_laneDetector.stacksManager._racks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                                break;
                            case 80:
                                Instantiate(_laneDetector.stacksManager._racks[secondObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                                break;
                        }
                        
                        //Instantiate(_laneDetector.stacksManager._racks[secondObject], _otherPoints[1].transform.position, _otherPoints[1].transform.rotation);
                        break;
                    case 80:
                        Instantiate(_laneDetector.stacksManager._racks[thirdObject], _otherPoints[3].transform.position, _otherPoints[3].transform.rotation);
                        break;
                }
            }
        }

        else
        {
            Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
        }
        
        //Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
    }

    public void CreateNewRightRack(Transform _spawnPoint)
    {
        _spawnPoint = _spawnPoints[1].transform;
        StartCoroutine(WaitNewRightRack(_spawnPoint));
    }

    IEnumerator WaitNewRightRack(Transform _originPoint)
    {
        yield return new WaitForSeconds(.2f);

        if (_laneDetector != null)
        {
            if (Width == _laneDetector._rightWidth)
            {
                Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
            }

            else
            {
                switch (_laneDetector._rightWidth)
                {
                    case 40:
                        switch(Width)
                        {
                            case 40:
                                Instantiate(_laneDetector.stacksManager._racks[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                break;
                            case 61:
                                Instantiate(_laneDetector.stacksManager._racks[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                                break;
                            case 80:
                                Instantiate(_laneDetector.stacksManager._racks[firstObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                                break;
                        }

                        //Instantiate(_laneDetector.stacksManager._racks[firstObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                        break;
                    case 61:
                        Instantiate(_laneDetector.stacksManager._racks[secondObject], _otherPoints[0].transform.position, _otherPoints[0].transform.rotation);
                        break;
                    case 80:
                        Instantiate(_laneDetector.stacksManager._racks[thirdObject], _otherPoints[2].transform.position, _otherPoints[2].transform.rotation);
                        break;
                }
            }
        }

        else
        {
            Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
        }

        //Instantiate(_stacks[1], _originPoint.transform.position, _originPoint.transform.rotation);
    }
}

 
