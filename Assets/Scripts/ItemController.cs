using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public Transform player;
    public Transform camera;
    Transform followNpc;

    Rigidbody rb;

    bool pickedUp;
    bool npcPickedUp;

    Vector3 targetPos;

    float speed = 15f;
    float adjustHeight = 0.15f;
    float maxMoveDistance = 2.5f;
    float maxMoveHeight = 4f;
    float minMoveHeight = 1f;
    float holdHeight = 2.5f;

    float mouseSens = 100f;
    float xRotation = 0f;
    float zRotation = 0f;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {

        pickedUp = false;
        npcPickedUp = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (pickedUp) {

            Plane plane = new Plane(Vector3.up,transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hit = 0f;

            if (plane.Raycast(ray, out hit)) {

                hit = maxMoveDistance;

                targetPos = ray.GetPoint(hit);
                //targetPos.y -= adjustHeight;
/*
                if (!fly) {

                    if (targetPos.y > maxMoveHeight) {

                        targetPos.y = maxMoveHeight;

                    }

                    else if (targetPos.y < minMoveHeight) {

                        targetPos.y = minMoveHeight;

                    }
s
                }
                */
                if (Input.GetKey(KeyCode.R)) {

                    mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
                    mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

                    xRotation += mouseY;
                    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                    zRotation -= mouseX;
                    zRotation = Mathf.Clamp(90f, -90f, zRotation);

                    transform.localRotation = Quaternion.Euler(xRotation, zRotation, 0f);

                }

            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        } else if (npcPickedUp) {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(
                followNpc.position.x, followNpc.position.y + holdHeight, followNpc.position.z), .25f);

        }

    }

    public void pickUp_drop() {

        pickedUp = !pickedUp;
        npcPickedUp = false;

        if (pickedUp) {

            rb.useGravity = false;
            rb.isKinematic = true;

        } else {

            rb.useGravity = true;
            rb.isKinematic = false;

        }

    }

    public void npc_pickUp(Transform npc) {

        bool moveBall = false;

        if (!moveBall) {

            pickedUp = false;
            npcPickedUp = true;

            followNpc = npc;
            followNpc.position += new Vector3(0f, 3f, 0f);

            if (npcPickedUp) {

                rb.useGravity = false;
                rb.isKinematic = true;

            } else {

                rb.useGravity = true;
                rb.isKinematic = false;

            }

            moveBall = true;

        }

    }
}
