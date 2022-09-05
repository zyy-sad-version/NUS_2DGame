using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject Timmyobj;
    bool passby;
    Scene scene;
    public float distance1,distance2,distance3,distance4,height;

    // Start is called before the first frame update
    void Start()
    {
        scene= SceneManager.GetActiveScene();   
        if(scene.name == "Level4" || scene.name == "Level3"){
        if(scene.name == "Level4"){
            distance1 = 18;
            distance2 = 38;
            distance3 = 56;
            distance4 = 0;
            height = 5;
        }
        else if(scene.name == "Level3"){
            distance1 = 28;
            distance2 = 28;
            distance3 = 126;
            distance4 = -70;
            height = 6;
        }
            passby = false;
            Timmyobj = GameObject.Find("Timmy");
            Debug.Log(Timmyobj.transform.localPosition);   
            Vector3 q = transform.localPosition;
            q.z = height;
            transform.localPosition = q;
        }

    }

    // Update is called once per frame
    void Update()
    {
        scene= SceneManager.GetActiveScene();   
        if(scene.name == "Level4" || scene.name == "Level3"){
            Vector3 q = transform.localPosition;
            Vector3 p = Timmyobj.transform.localPosition;
            if ((p.x <= (q.x + distance1)) && (p.x >= (q.x - distance2)) && (p.y <= (q.y + distance3)) && (p.y >= (q.y - distance4))){
                q.z = -1;
                passby = true;
            }   
            else if (passby)    q.z = -1;
            transform.localPosition = q;
        }       
    }
}
