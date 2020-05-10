//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldsLootedText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "worlds.looted : " + PlayerPrefs.GetInt("WORLDS_LOOTED");
    }

    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "worlds.looted : " + GameManager.instance.WorldsLooted;
    }
}
