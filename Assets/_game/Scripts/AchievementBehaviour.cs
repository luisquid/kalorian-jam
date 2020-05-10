//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum Achievement {
                    CLICKS,
                    WORLDS,
                    WHITE,
                    BLUE,
                    GOLD,
                    RAND1,
                    RAND2
                    };

public class AchievementBehaviour : MonoBehaviour
{
    [SerializeField]
    Achievement rule;
    public float Quantity;
    public Sprite LootGraphic;
    private Button BTN_Achievement;

    private void Start()
    {
        CheckLoot();
    }

    private void OnEnable()
    {
        CheckLoot();
    }

    void CheckLoot()
    {
        BTN_Achievement = GetComponent<Button>();
        switch(rule)
        {
            case Achievement.CLICKS:
                if (Quantity < PlayerPrefs.GetInt("TOTAL_LOOT"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.WORLDS:
                if (Quantity < PlayerPrefs.GetInt("WORLDS_LOOTED"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.WHITE:
                if (Quantity < PlayerPrefs.GetInt("WHITE_LOOTED"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.BLUE:
                if (Quantity < PlayerPrefs.GetInt("BLUE_LOOTED"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.GOLD:
                if (Quantity < PlayerPrefs.GetInt("GOLD_LOOTED"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.RAND1:
                if (Quantity < PlayerPrefs.GetInt("TOTAL_LOOT"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            case Achievement.RAND2:
                if (Quantity < PlayerPrefs.GetInt("TOTAL_LOOT"))
                    BTN_Achievement.interactable = true;
                else
                    BTN_Achievement.interactable = false;
                break;
            default:
                Debug.Log("Case not defined");
                break;
        }
    }

    public void GetLoot()
    {
        BTN_Achievement.GetComponent<Image>().sprite = LootGraphic;

        switch(rule)
        {
            case Achievement.CLICKS:
                
                break;
            case Achievement.WORLDS:
          
                break;
            case Achievement.WHITE:

                break;
            case Achievement.BLUE:
               
                break;
            case Achievement.GOLD:

                break;
            case Achievement.RAND1:
            
                break;
            case Achievement.RAND2:

                break;
            default:
                Debug.Log("Case not defined");
                break;
        }
    }
}
