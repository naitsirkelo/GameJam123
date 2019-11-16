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
        if (hit.gameObject.CompareTag("Collectable") || hit.gameObject.CompareTag("Key")) {

            hit.gameObject.GetComponent<ItemController>().npc_pickUp(transform);

        }
    }
}
