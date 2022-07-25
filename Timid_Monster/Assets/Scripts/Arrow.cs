using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private const float kEggSpeed = 40f; //egg move speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime); //move up
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.name == "Boss1") || (collision.gameObject.name == "Boss2(Clone)") || (collision.gameObject.name == "Boss3(Clone)")){
            Destroy(transform.gameObject);  // kills self
        }
    }
}
