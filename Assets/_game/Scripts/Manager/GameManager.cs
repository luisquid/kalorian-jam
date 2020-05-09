using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIController uiCtrl;
    public ShipController shipCtrl;
    public float lootCounter = 0;

    public void UpdateCounter(float _increment)
    {
        lootCounter += _increment;
        uiCtrl.TXT_Counter.text = lootCounter.ToString();
    }
}
