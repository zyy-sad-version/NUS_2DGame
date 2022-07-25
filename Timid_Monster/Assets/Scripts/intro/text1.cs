using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text1 : MonoBehaviour
{
    public float charsPerSecond = 0.05f;//time interval
    private string words;

    private bool isActive = false;
    private float timer;
    private Text myText;
    private int currentPos=0;

    // Start is called before the first frame update
    void Start()
    {
        words =  "Hello! My name is Timmy. \r\nI know all along that \r\n nobody likes a scary monster. ";
        charsPerSecond = 0.04f;
        timer = 0;
        isActive = true;
        myText = GetComponent<Text> ();
        myText.text = ""; //update text
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
    }

    public void StartEffect(){
        isActive = true;
    }

    void OnStartWriter(){
        if(isActive){
            timer += Time.deltaTime;
            if(timer>=charsPerSecond){// judge timer
                timer = 0;
                currentPos++;
                myText.text = words.Substring (0,currentPos);//update text

                if(currentPos>=words.Length) {
                    OnFinish();
                }
            }

        }
    }

    void OnFinish(){
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }
}
