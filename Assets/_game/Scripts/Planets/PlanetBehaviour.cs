//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public PlanetType Properties;
    public GameObject DeadParticles;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        FindObjectOfType<InputTest>().clickFunction += CalculateClicks;
    }

    private void Update()
    {
        if (transform.localScale.x < 1)
            transform.localScale = transform.localScale + new Vector3(0.95f, 0.95f, 0.95f) * Time.deltaTime;
    }

    public void CalculateClicks(int _clicks)
    {
        float increment = ((GameManager.instance.CurrentLootCounter * 100f) * 0.0002f / Properties.ClicksToExplode) ;
        transform.localScale = new Vector3(transform.localScale.x + increment, transform.localScale.y + increment, transform.localScale.z + increment);

        if(_clicks >= Properties.ClicksToExplode)
        {
            ExplodeAndLoot();
        }
    }

    public void ExplodeAndLoot()
    {
        //Loot Section
        GameManager.instance.TotalLootCounter += GameManager.instance.CurrentLootCounter;
        GameManager.instance.CurrentLootCounter = 0;
        GameManager.instance.WorldsLooted++;

        switch(Properties.ID)
        {
            case 0:
                PlayerPrefs.SetInt("WHITE_LOOTED", PlayerPrefs.GetInt("WHITE_LOOTED") + 1);
            
                break;

            case 1:
                PlayerPrefs.SetInt("BLUE_LOOTED", PlayerPrefs.GetInt("BLUE_LOOTED") + 1);

                break;

            case 2:
                PlayerPrefs.SetInt("GOLD_LOOTED", PlayerPrefs.GetInt("GOLD_LOOTED") + 1);

                break;

            default:

                break;
        }
        PlayerPrefs.SetInt("TOTAL_LOOT", GameManager.instance.TotalLootCounter);
        PlayerPrefs.SetInt("WORLDS_LOOTED", GameManager.instance.WorldsLooted);

        //Animation and visual
        GameManager.instance.shipCtrl.anim.SetTrigger("DoTheThing");
        GameManager.instance.camShake.StartCameraShake(3f, 30f, 50f, true);
        Instantiate(DeadParticles, transform.position, Quaternion.identity);
        
        //New Planet
        GameManager.instance.planetMngr.CurrentPlanet = null;

        //Desuscribe and destroy
        FindObjectOfType<InputTest>().clickFunction -= CalculateClicks;
        Destroy(gameObject);
    }
}
