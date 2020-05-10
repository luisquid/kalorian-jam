//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public PlanetType Properties;

    private void Start()
    {
        FindObjectOfType<InputTest>().clickFunction += CalculateClicks;
    }

    public void CalculateClicks(int _clicks)
    {
        Debug.Log(Properties.ClicksToExplode - _clicks + " CLICKS LEFT");

        if(_clicks >= Properties.ClicksToExplode)
        {
            ExplodeAndLoot();
        }
    }

    public void ExplodeAndLoot()
    {
        Debug.Log("OKAY BBYE");
        //Loot Section
        GameManager.instance.TotalLootCounter += GameManager.instance.CurrentLootCounter;
        GameManager.instance.CurrentLootCounter = 0;

        //Animation and visual
        GameManager.instance.shipCtrl.anim.SetTrigger("DoTheThing");
        GameManager.instance.camShake.StartCameraShake(3f, 30f, 50f, true);

        //New Planet
        GameManager.instance.planetMngr.GetNewPlanet();

        //Desuscribe and destroy
        FindObjectOfType<InputTest>().clickFunction -= CalculateClicks;
        Destroy(gameObject);
    }
}
