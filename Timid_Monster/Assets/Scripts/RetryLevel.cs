using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public GameProperty gameproperty;
    // Start is called before the first frame update
    void Start()
    {
        gameproperty = GameObject.FindObjectOfType<GameProperty>();
        this.GetComponent<Button>().onClick.AddListener(OnClick);

    }

    // Update is called once per frame
    void OnClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Fail"){
            SceneManager.LoadScene(gameproperty.sceneName);
        }
        else{
        SceneManager.LoadScene(scene.name);
  
        }
    }
}
