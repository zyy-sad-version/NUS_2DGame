using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossDialog2 : MonoBehaviour
{
    public TimmyInBoss timmy;
    public Button nextBtn;
    public Image dialogBox;
    public Image timmyImg;
    public Image friendImg;
    public Text dialog;
    

    public int dialogPocess = 1;
   
    // Start is called before the first frame update
    void Start()
    {
       timmy.OneMove=0f;
       SetAllInactive();
        
    }

    // Update is called once per frame
    void Update()
    {
            SetBtnActive();
            SetBoxActive();
            switch(dialogPocess){
                case 1:{
                    SetTextActive();
                    SetTimmyActive();
                    break;
                }
                case 2:{
                    SetTimmyInactive();
                    SetFriendActive();
                    ChangeText("Your loneliness is what\nmakes me who I am.");
                    break;
                }
                case 3:{                    
                    ChangeText("You've been used to \nliving alone for years.");
                    break;
                }
                case 4:{
                    ChangeText("You don't need those friends.");
                    break;
                }
                case 5:{
                    ChangeText("Return to the abyss of loneliness.");
                    break;
                }
                case 6:{
                    timmy.OneMove = 15f;
                     SetAllInactive(); 
                     break;
                }

        }
        if(timmy.Victory){
            SetBtnActive();
            SetBoxActive();
            switch(dialogPocess){
                case 6:{
                    SetTextActive();
                    ChangeText("You are wrong.");
                    SetTimmyActive();
                    break;
                }
                case 7:{
                    ChangeText("I will live happily with my friends.");
                    break;
                }
                case 8:{
                    ChangeText("It's time to keep going!");
                    break;
                }
                case 9:{
                    SceneManager.LoadScene("BossScene3");
                    break;
                }
            }
        }
    }

    void SetAllInactive(){
         SetBoxInactive();
        SetBtnInactive();
        SetTimmyInactive();
        SetFriendInactive();
        SetTextInactive();

    }

    void SetBtnActive(){
        nextBtn.gameObject.SetActive(true);
    }
    void SetBoxActive(){
        dialogBox.color = new Color(dialogBox.color.r, dialogBox.color.g, dialogBox.color.b, 255);
    }
    void SetTimmyActive(){
        timmyImg.color = new Color(timmyImg.color.r, timmyImg.color.g, timmyImg.color.b, 255);
    }
    void SetFriendActive(){
        friendImg.color = new Color(friendImg.color.r, friendImg.color.g, friendImg.color.b, 255);
    }
    void SetTextActive(){
        dialog.gameObject.SetActive(true);
    }


    void SetBtnInactive(){
        nextBtn.gameObject.SetActive(false);
    }
    void SetBoxInactive(){
        dialogBox.color = new Color(dialogBox.color.r, dialogBox.color.g, dialogBox.color.b, 0);
    }
    void SetTimmyInactive(){
        timmyImg.color = new Color(timmyImg.color.r, timmyImg.color.g, timmyImg.color.b, 0);
    }
    void SetFriendInactive(){
        friendImg.color = new Color(friendImg.color.r, friendImg.color.g, friendImg.color.b, 0);
    }
    void SetTextInactive(){
        dialog.gameObject.SetActive(false);
    }
    void ChangeText(string text){
        dialog.text = text;
    }

    
}
