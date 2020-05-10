using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float Speed;
    public GameObject MuzzlePrefab;
    public GameObject HitPrefab;
    public GameObject ScorePrefab;

    private void Start()
    {
        GameObject muzzleFX = Instantiate(MuzzlePrefab, transform.position, Quaternion.identity);

        Destroy(muzzleFX, transform.GetChild(0).GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject, 9f);
    }

    void Update()
    {
        transform.position += transform.up * (Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion conRot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 contrPos = contact.point;

        GameObject hitFX = Instantiate(HitPrefab, contrPos, conRot);
        Destroy(hitFX, transform.GetChild(0).GetComponent<ParticleSystem>().main.duration);
        if(collision.collider.CompareTag("Planet"))
        {
            Instantiate(ScorePrefab, contrPos, Quaternion.identity);
            GameManager.instance.camShake.StartCameraShake(0.3f, 2.0f, 3.0f);
            Speed = 0;
            Destroy(gameObject);
        }     
    }
}
