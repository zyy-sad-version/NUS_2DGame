using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GotoBoss_Button : MonoBehaviour
{
     public GameProperty gameProperty;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().interactable = false;
        this.GetComponent<Button>().onClick.AddListener(OnClick);
       gameProperty = GameObject.FindObjectOfType<GameProperty>();
       
    }

    void OnClick()
    {
        if(!gameProperty.checkPoint5){
            SceneManager.LoadScene("BossScene");
        }
        else{
            if(!gameProperty.checkPoint6){
                SceneManager.LoadScene("BossScene2");
            }
            else{
                if(!gameProperty.checkPoint7){
                    SceneManager.LoadScene("BossScene3");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameProperty.checkPoint1&gameProperty.checkPoint2& gameProperty.checkPoint3& gameProperty.checkPoint4){
                this.GetComponent<Button>().interactable = true;

            }
           
    }
}
