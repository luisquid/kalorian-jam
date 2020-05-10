using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float Speed;
    public GameObject MuzzleParticles;
    public GameObject HitParticles;

    private void Start()
    {
        StartCoroutine(KillProjectile());
    }

    void Update()
    {
        transform.position += transform.up * (Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Planet"))
        {
            print("Yes");

            GameManager.instance.camShake.StartCameraShake(2.0f, 3.0f);
            Speed = 0;
            Destroy(gameObject);
        }     
    }

    IEnumerator KillProjectile()
    {
        yield return new WaitForSeconds(9f);

        Destroy(gameObject);
    }
}
