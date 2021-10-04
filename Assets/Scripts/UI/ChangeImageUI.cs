using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageUI : MonoBehaviour
{

    public Sprite sprite1;
    public GameObject img;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(delegate { ChangeImg(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeImg()
    {
        img.GetComponent<Image>().sprite = sprite1;
    }
}
