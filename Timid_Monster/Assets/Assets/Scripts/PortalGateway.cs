 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class PortalGateway : MonoBehaviour
 {
    public Transform goToPos;
    private Transform playerPos;
 
	void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;	
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Timmy") {
            if(goToPos.name == "Door32"){
                playerPos.transform.position = new Vector3(goToPos.transform.position.x+14,goToPos.transform.position.y,goToPos.transform.position.z-1);
            }
            else if(goToPos.name == "Door31"){
                playerPos.transform.position = new Vector3(goToPos.transform.position.x,goToPos.transform.position.y-14,goToPos.transform.position.z-1);
            }
            else if(goToPos.name == "Door42" || goToPos.name == "Door44"){
                playerPos.transform.position = new Vector3(goToPos.transform.position.x-14,goToPos.transform.position.y,goToPos.transform.position.z-5);
            }
            else if(goToPos.name == "Door41"){
                playerPos.transform.position = new Vector3(goToPos.transform.position.x+14,goToPos.transform.position.y,goToPos.transform.position.z-5);
            }
            else if(goToPos.name == "Door43"){
                playerPos.transform.position = new Vector3(goToPos.transform.position.x,goToPos.transform.position.y+14,goToPos.transform.position.z-5);
            }
        }
    }


}
