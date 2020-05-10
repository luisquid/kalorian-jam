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
