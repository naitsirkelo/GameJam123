﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int clickDistance = 3;
    public Camera camera;

    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

              Ray ray = camera.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, clickDistance)) {

                print("Found " + hit.transform.gameObject + " - distance: " + hit.distance);

                if (hit.transform.gameObject.name == "Collectable") {

                    collectable.GetComponent<ItemController>().pickUp_drop();

                }

            }

        }

    }
}
