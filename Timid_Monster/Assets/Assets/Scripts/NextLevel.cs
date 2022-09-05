using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        scene  = SceneManager.GetActiveScene();
            switch(scene.name){
                case "TIMMYScene":{
                    SceneManager.LoadScene("Level1");
                    break;
                }
                case "Level1":{
                    SceneManager.LoadScene("Level2");
                    break;
                }
                case "Level2":{
                    SceneManager.LoadScene("Level3");
                    break;
                }
                case "Level3":{
                    SceneManager.LoadScene("Level4");
                    break;
                }
                case "Level4":{
                    SceneManager.LoadScene("BossScene");
                    break;
                }
                
            }
    }
}
