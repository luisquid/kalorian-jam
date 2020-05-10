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
        transform.GetComponent<Image>().sprite = LootGraphic;

        switch(rule)
        {
            case Achievement.CLICKS:
                GameManager.instance.playerStats.counterMultiplier = 2f;
                GameManager.instance.AchievementText.text = "bullets shoot twice!";
                break;
            case Achievement.WORLDS:
                GameManager.instance.playerStats.counterMultiplier = 4f;
                GameManager.instance.AchievementText.text = "bullets shoot twice! x2";
                break;
            case Achievement.WHITE:
                //SKIN
                GameManager.instance.AchievementText.text = "the white chariot comes";
                GameManager.instance.shipCtrl.GetComponent<MeshRenderer>().materials[1].color = Color.white;
                break;
            case Achievement.BLUE:
                //SKIN
                GameManager.instance.AchievementText.text = "what's the point of feeling blue?";

                GameManager.instance.shipCtrl.GetComponent<MeshRenderer>().materials[1].color = Color.blue;
                break;
            case Achievement.GOLD:
                //SKIN
                GameManager.instance.AchievementText.text = "don't paint me black when i used to be golden";
                GameManager.instance.shipCtrl.GetComponent<MeshRenderer>().materials[1].color = Color.yellow;

                break;
            case Achievement.RAND1:
                //GRAPHIC
                GameManager.instance.AchievementText.text = "wait, what did you do";
                GameManager.instance.shipCtrl.GetComponent<MeshRenderer>().materials[1].color = Color.red;
                break;
            case Achievement.RAND2:
                //GRAPHIC
                GameManager.instance.AchievementText.text = "you never should've come here";

                break;
            default:
                Debug.Log("Case not defined");
                break;
        }

        GameManager.instance.AchievementText.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        GameManager.instance.AchievementText.gameObject.SetActive(false);
    }
}
