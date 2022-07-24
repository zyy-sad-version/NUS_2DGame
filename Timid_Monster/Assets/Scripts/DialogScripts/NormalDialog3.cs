using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalDialog3 : MonoBehaviour
{
    public Timmy timmy;
    public Button nextBtn;
    public Image dialogBox;
    public Image timmyImg;
    public Image friendImg;
    public Text dialog;
    public Button nextLevel;
    public Button mainMenu;

    public Image fire;

    public int dialogPocess = 1;
   
    // Start is called before the first frame update
    void Start()
    {
       SetAllInactive();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timmy.Victory){
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
                    ChangeText("That's great!\nI've wanted to be your\n friend for a long time.");
                    break;
                }
                case 3:{
                    SetTimmyActive();
                    SetFriendInactive();
                    ChangeText("Turns out someone really likes me.");
                    
                    break;
                }
                case 4:{
                    SetFireActive();
                    ChangeText("What did I find?");
                    break;
                }
                case 5:{
                    ChangeText("It's a flame!");
                    break;
                }
                case 6:{
                    SetTimmyInactive();
                    ChangeText("Timmt get the Flame of Confidence.");
                    SetBtnInactive();
                    SetNextMainBtnActive();
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
        SetNextMainBtnInactive();
        SetFireInactive();

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
    void SetNextMainBtnActive(){
        nextLevel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
    void SetFireActive(){
        fire.color = new Color(fire.color.r, fire.color.g, fire.color.b, 255);

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
    void SetNextMainBtnInactive(){
        nextLevel.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }
    void ChangeText(string text){
        dialog.text = text;
    }
    void SetFireInactive(){
        fire.color = new Color(fire.color.r, fire.color.g, fire.color.b, 0);
    }

    
}
