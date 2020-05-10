using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoSingleton<GameManager>
{
    public UIController uiCtrl;
    public ShipController shipCtrl;
    public CameraShake camShake;
    public PlanetManager planetMngr;
    public PlayerStats playerStats;

    public TextMeshProUGUI AchievementText;

    public int WorldsLooted = 0;
    public int TotalLootCounter = 0;
    public int CurrentLootCounter = 0;
    public bool BlockShooting = false;

    public bool ResetPlayerPrefs;

    private void Start()
    {
        if (ResetPlayerPrefs)
            PlayerPrefs.DeleteAll();

        TotalLootCounter = PlayerPrefs.GetInt("TOTAL_LOOT");
        WorldsLooted = PlayerPrefs.GetInt("WORLDS_LOOTED");
        uiCtrl.TXT_Counter.text = TotalLootCounter.ToString();
    }

    public void UpdateCounter(int _increment)
    {
        CurrentLootCounter += _increment * (int)playerStats.counterMultiplier;
        uiCtrl.TXT_Counter.text = (TotalLootCounter + CurrentLootCounter).ToString();
    }
}
