using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public float kEggSpeed = 80f; //egg move speed

    private float boundl;
    private float boundr;
    private float boundd;
    private float boundu;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch(scene.name){
            case "BossScene":{
                boundl = -211;
                boundr = 209;
                boundd = -137;
                boundu = 133;
                break;
            }
            case "BossScene2":{
                boundl = -203;
                boundr = 217;
                boundd = -136;
                boundu = 134;
                break;
            }
            case "BossScene3":{
                boundl = -205;
                boundr = 215;
                boundd = -132;
                boundu = 138;
                break;
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime); //move up
        Vector3 p = transform.localPosition;
        if((p.x <= boundl) || (p.x >= boundr) || (p.y <= boundd) || (p.y >= boundu))    Destroy(transform.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.name == "Boss1") || (collision.gameObject.name == "Boss2(Clone)") || (collision.gameObject.name == "Boss3(Clone)")){
            Destroy(transform.gameObject);  // kills self
        }
    }
}
