using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int clickDistance = 4;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

              Ray ray = camera.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, clickDistance)) {

                print("Found " + hit.transform.gameObject + " - distance: " + hit.distance);

                if (hit.transform.gameObject.tag == "Collectable") {

                    hit.transform.gameObject.GetComponent<ItemController>().pickUp_drop();

                }

            }

        }

    }
}
