using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Animator anim;
    public float MaxTime;

    [Header("CANNON PROPERTIES")]
    public GameObject BulletProjectile;
    public Transform BulletSpawnLeft;
    public Transform BulletSpawnRight;
    
    private float timeToHover;
    private bool isLeft = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        //timeToHover = Random.Range(1, MaxTime);
        //StartCoroutine(WaitForHover());
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        anim.SetTrigger("DoTheThing");
    //}

    public void ShootProjectile()
    {
        if (GameManager.instance.BlockShooting)
            return;

        GameObject bullet = Instantiate(BulletProjectile, 
                                        isLeft ? BulletSpawnLeft.position : BulletSpawnRight.position, 
                                        isLeft ? BulletSpawnLeft.rotation : BulletSpawnRight.rotation);
        isLeft = !isLeft;   
    }

    IEnumerator WaitForHover()
    {
        yield return new WaitForSeconds(timeToHover);

        GameManager.instance.BlockShooting = true;
        anim.SetTrigger("DoTheThing");
        timeToHover = Random.Range(1, MaxTime);
        StartCoroutine(WaitForHover());
    }

    public void UnblockShooting()
    {
        GameManager.instance.BlockShooting = false;
    }

    public void BlockShooting()
    {
        GameManager.instance.BlockShooting = true;
    }

    public void SetLeft(int _status)
    {
        print(_status == 0);
        anim.SetBool("Left", _status == 0 ? true : false);
    }
}
