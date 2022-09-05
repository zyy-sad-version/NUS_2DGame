using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWall : MonoBehaviour
{
    public SpriteRenderer sp;
    public AudioClip Special;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "Timmy"){
            sp.color = new Color(sp.color.r,sp.color.g,sp.color.b,0.7f);
            GetComponent<AudioSource>().clip = Special;
            GetComponent<AudioSource>().Play();
        }
    }
}
