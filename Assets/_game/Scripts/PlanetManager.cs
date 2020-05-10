//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public PlanetDistro Distribution;
    public Transform SpawnPoint;
    public GameObject CurrentPlanet;
    private void Start()
    {
        GetNewPlanet();
    }

    void Update()
    {
        
    }
    
    public void GetNewPlanet()
    {
        int planetProb = Random.Range(1, 100);

        CurrentPlanet = Instantiate(Distribution.Planets[GetPlanetToSpawn(planetProb)], SpawnPoint.position, Quaternion.identity);
    }

    public int GetPlanetToSpawn(float _probability)
    {
        int planetIndex = 0;

        planetIndex = (_probability > Distribution.WhiteProbab && _probability < Distribution.GoldProbab ? 1 : (_probability >= Distribution.GoldProbab) ? 2 : 0);

        return planetIndex;
    }
}
