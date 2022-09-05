using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBuff : MonoBehaviour
{
    public GameProperty gameProperty;
    public AudioClip Gift;
    // Start is called before the first frame update
    void Start()
    {
        gameProperty = GameObject.FindObjectOfType<GameProperty>();    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "Timmy"){
            GetComponent<AudioSource>().clip = Gift;
            GetComponent<AudioSource>().Play();
            switch(gameObject.name){
                case "GiftAttack":{
                    gameProperty.gift1=true;
                    break;
                }
                case "GiftAttackSpeed":{
                    gameProperty.gift2=true;
                    break;
                }
                case "GiftBarrier":{
                    gameProperty.gift3=true;
                    break;
                }
                case "GiftEnergy":{
                    gameProperty.gift4=true;
                    break;
                }
            }
        }
    }

}
