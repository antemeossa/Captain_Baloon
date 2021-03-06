using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public static StoreController instance;

    public StoreButton selectedBtn;

    [SerializeField]
    private List<StoreButton> buttonList;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        

    }

    private void Start()
    {
       
    }

    public void getSelectedSkin()
    {
        
            //selectedBtn = buttonList[0];
        
            selectedBtn = buttonList[PlayerPrefs.GetInt("selectedSkinIndex")];
       
        equipSkin();
        
    }

    public void equipSkin()
    {
        if(selectedBtn == null)
        {
            selectedBtn = buttonList[0];
        }

            GameManager.instance.playerSkinHat.sprite = selectedBtn.baloonHat;
            GameManager.instance.playerSkinBaloon.sprite = selectedBtn.baloonSkin;
            GameManager.instance.playerSkinTail.sprite = selectedBtn.baloonTail;
        
        
    }

        

    public void setSelectedButton(StoreButton storebtn)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponent<StoreButton>().selected = false;
        }

        storebtn.selected = true;
        selectedBtn = storebtn;

        for (int i = 0; i < buttonList.Count; i++)
        {
            if(buttonList[i].selected == true)
            {
                PlayerPrefs.SetInt("selectedSkinIndex", i);
                buttonList[i].buyButtonText.text = "Equipped";
                buttonList[i].buyButtonText.color = Color.white;
                buttonList[i].btn.image.color = Color.red;
            }
            else
            {
                if (PlayerPrefs.GetInt(buttonList[i].desiredText) == 0)
                {
                    PlayerPrefs.SetInt(buttonList[i].desiredText, 0);
                    buttonList[i].btn.image.color = Color.yellow;
                }
                else
                {
                    PlayerPrefs.SetInt(buttonList[i].desiredText, 1);
                    buttonList[i].buyButtonText.text = "Equip";
                    buttonList[i].btn.image.color = Color.white;
                }

                
            }
        }
       
    }


    

   
}
