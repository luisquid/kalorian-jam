//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticles : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnPlanet());
    }

    IEnumerator SpawnPlanet()
    {
        yield return new WaitForSeconds(gameObject.GetComponentInChildren<ParticleSystem>().main.duration- 0.5f);

        GameManager.instance.planetMngr.GetNewPlanet();
        Destroy(gameObject, 0.5f);
    }
}
