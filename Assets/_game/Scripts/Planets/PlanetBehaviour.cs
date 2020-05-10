//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public int ClicksToExplode;

    private void Start()
    {
        FindObjectOfType<InputTest>().clickFunction += CalculateClicks;
    }

    public void CalculateClicks(int _clicks)
    {
        Debug.Log(ClicksToExplode - _clicks + " CLICKS LEFT");

        if(_clicks >= ClicksToExplode)
        {
            Debug.Log("I AM DEAD");
            GameManager.instance.TotalLootCounter += GameManager.instance.CurrentLootCounter;
            GameManager.instance.CurrentLootCounter = 0;
            GameManager.instance.shipCtrl.anim.SetTrigger("DoTheThing");
            GameManager.instance.camShake.StartCameraShake(3f, 30f, 50f, true);
        }
    }

    public void ExplodeAndLoot()
    {

    }
}
