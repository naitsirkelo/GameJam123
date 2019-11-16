using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {



    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Collectable") {
            Debug.Log("Hit ball");
            hit.gameObject.GetComponent<ItemController>().npc_pickUp(transform);

        }
    }
}
