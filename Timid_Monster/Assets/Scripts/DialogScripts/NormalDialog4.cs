using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalDialog4 : MonoBehaviour
{
    public Timmy timmy;
    public Button nextBtn;
    public Image dialogBox;
    public Image timmyImg;
    public Image friendImg;
    public Text dialog;
    public Button nextLevel;
    public Button mainMenu;

    public Image blade;
    public Image bow;

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
                    ChangeText("Me too!");
                    break;
                }
                case 3:{
                    SetTimmyActive();
                    SetFriendInactive();
                    ChangeText("Really? I'm so happy!");
                    
                    break;
                }
                
                case 4:{
                    
                    ChangeText("I have so many friends now.\nI don't feel lonely anymore.");
                    break;
                }
                case 5:{
                    SetbladeActive();
                    ChangeText("Wait, is that a shining sword?");
                    break;
                }
                case 6:{
                    SetTimmyInactive();
                    ChangeText("Timmy gets the Flame of Confidence.");
                    
                    break;
                }
                case 7:{
                    SetbladeInactive();
                    ChangeText("Suddenly,\nthe sword acts like a magnet\n to the other fragments.");
                    break;
                }
                case 8:{
                    SetBowActive();
                    ChangeText("As the light fades,\nTimmy gets a magical bow and arrow.\nTimmy seems to be full of strength\nas he holds the bow.");
                    break;
                }
                case 9:{
                    SetTimmyActive();
                    
                    ChangeText("This bow will help me\ndefeat my inner demons!");
                    break;
                }
                case 10:{
                    SetBowInactive();
                    ChangeText("It's time to go");
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
        SetbladeInactive();
        SetBowInactive();
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
    void SetbladeActive(){
        blade.color = new Color(blade.color.r, blade.color.g, blade.color.b, 255);

    }
    void SetBowActive(){
        bow.color = new Color(bow.color.r, bow.color.g, bow.color.b, 255);
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
    void SetbladeInactive(){
        blade.color = new Color(blade.color.r, blade.color.g, blade.color.b, 0);
    }
    void SetBowInactive(){
        bow.color = new Color(bow.color.r, bow.color.g, bow.color.b, 0);
    }

    
}
