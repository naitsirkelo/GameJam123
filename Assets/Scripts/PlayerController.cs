using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int clickDistance = 4;

    public Camera camera;

    Transform item;

    bool holdingItem;

    string holding;

    // Start is called before the first frame update
    void Start()
    {
        holdingItem = false;
        holding = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, clickDistance)) {

                print("Found " + hit.transform.gameObject + " - distance: " + hit.distance);

                if (hit.transform.gameObject.CompareTag("Collectable") || hit.transform.gameObject.CompareTag("Key")) {

                    Transform item = hit.transform;
                    holdingItem = true;

                    hit.transform.gameObject.GetComponent<ItemController>().pickUp_drop();
                    holding = hit.transform.gameObject.tag;

                    Debug.Log(holding);

                }

            }

        }

        if (Input.GetKeyDown(KeyCode.Q)) {

            Debug.Log("Drop item");

        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Door") && holding == "Key") {

            hit.gameObject.GetComponent<DoorController>().correctKey();

        }
    }
}
