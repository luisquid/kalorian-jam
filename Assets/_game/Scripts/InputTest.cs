using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public float FireRate = 1f;

    private float timeToFire = 0.0f;

    public delegate void PlanetClicked(int _clicks);
    public PlanetClicked clickFunction;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && timeToFire <= 0.0f && !GameManager.instance.BlockShooting)
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.CompareTag("Planet"))
                {
                    Debug.Log("SHOOT");

                    GameManager.instance.UpdateCounter(1);
                    clickFunction(GameManager.instance.CurrentLootCounter);

                    GameManager.instance.shipCtrl.anim.SetTrigger("Shoot");
                    GameManager.instance.shipCtrl.ShootProjectile();
                }
            }

            timeToFire = FireRate;
        }

        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
}
