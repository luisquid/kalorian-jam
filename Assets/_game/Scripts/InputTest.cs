using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.CompareTag("Ship"))
                {
                    Debug.Log("SHOOT");
                    GameManager.instance.UpdateCounter(1);
                    GameManager.instance.shipCtrl.anim.SetTrigger("Shoot");
                }
            }
        }
    }
}
