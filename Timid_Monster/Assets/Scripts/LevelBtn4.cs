using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelBtn4 : MonoBehaviour
{
     public GameProperty gameProperty;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().interactable = false;
        this.GetComponent<Button>().onClick.AddListener(OnClick);
       gameProperty = GameObject.FindObjectOfType<GameProperty>();
    }

    // Update is called once per frame
    void OnClick()
    {
        SceneManager.LoadScene("Level4");
    }
    void Update(){
        if(gameProperty.checkPoint1&gameProperty.checkPoint2& gameProperty.checkPoint3){
                this.GetComponent<Button>().interactable = true;

            }
    }
}
