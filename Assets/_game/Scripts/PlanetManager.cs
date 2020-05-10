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
    
    public void GetNewPlanet()
    {
        int planetProb = Random.Range(1, 100);
        CurrentPlanet = Instantiate(Distribution.Planets[GetPlanetToSpawn(planetProb)], SpawnPoint.position, Quaternion.identity);
    }

    public int GetPlanetToSpawn(int _probability)
    {
        int planetIndex = 0;

        if (_probability > Distribution.GoldProbab)
            planetIndex = 2;
        else if (_probability > Distribution.BlueProbab)
            planetIndex = 1;
        else
            planetIndex = 0;

        return planetIndex;
    }
}
