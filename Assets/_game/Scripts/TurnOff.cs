//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public void TurnOffText()
    {
        GameManager.instance.AchievementText.gameObject.SetActive(false);
    }
}
