﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int clickDistance = 4;

    public Camera camera;

    Transform item;

    bool holdingItem;

    // Start is called before the first frame update
    void Start()
    {
        holdingItem = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

              Ray ray = camera.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, clickDistance)) {

                print("Found " + hit.transform.gameObject + " - distance: " + hit.distance);

                if (hit.transform.gameObject.tag == "Collectable") {

                    Transform item = hit.transform;
                    holdingItem = true;

                    hit.transform.gameObject.GetComponent<ItemController>().pickUp_drop();

                }

            }

        }

        if (Input.GetKeyDown(KeyCode.Q)) {

            if (holdingItem) {

                item.gameObject.GetComponent<ItemController>().pickUp_drop();

            }

        }

    }
}
