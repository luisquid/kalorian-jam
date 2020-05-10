using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIController uiCtrl;
    public ShipController shipCtrl;
    public CameraShake camShake;
    public PlanetManager planetMngr;

    public int TotalLootCounter = 0;
    public int CurrentLootCounter = 0;
    public bool BlockShooting = false;

    public void UpdateCounter(int _increment)
    {
        CurrentLootCounter += _increment;
        uiCtrl.TXT_Counter.text = (TotalLootCounter + CurrentLootCounter).ToString();
    }
}
