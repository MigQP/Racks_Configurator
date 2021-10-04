using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class Growing : MonoBehaviour
{ 
    private string startMessage = "Hello Player,It's Time to start Learning the Video Game Development";
    private string[] messages = { "Now, First Complete Your First Assingment", "Find Treasure", "Kill them" };

    public GameObject canvas;

    public Text Message;
    void Start()
    {
        setInitialization();
        showMessage();
    }

    void setInitialization()
    {
        Message = GameObject.Find("banner").GetComponent<Text>();
    }

    void showMessage()
    {

        StartCoroutine(disableCanvas(messages));
    }

    IEnumerator disableCanvas(string[] msg)
    {
        //Waiting time(Change to whatever value)
        float waitTime = 3;

        //Display the first message that is NOT in the array
        Message.text = startMessage;

        //Wait before starting to display each message in the array
        yield return new WaitForSeconds(waitTime);


        for (int i = 0; i < msg.Length; i++)
        {

            Message.text = msg[i];

            yield return new WaitForSeconds(waitTime);
        }
    }

}