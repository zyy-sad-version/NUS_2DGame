using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    this.GetComponent<Button>().onClick.AddListener(OnClick);

    }

    // Update is called once per frame
    void OnClick()
    {
        Scene scene = SceneManager.GetActiveScene ();
        SceneManager.LoadScene(scene.name);
    }
}
