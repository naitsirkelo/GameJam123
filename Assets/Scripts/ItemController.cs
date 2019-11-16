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
    public bool fly;

    Vector3 targetPos;
    Vector3 sizeVector;

    float changeFactor = 0.30f;
    float speed = 15f;
    float adjustHeight = 0.15f;
    float maxMoveDistance = 2.5f;
    float maxMoveHeight = 4f;
    float minMoveHeight = 1f;
    float holdHeight = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

        pickedUp = false;
        npcPickedUp = false;
        fly = false;
        rb = GetComponent<Rigidbody>();
        sizeVector = new Vector3(changeFactor, changeFactor, changeFactor);

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
                targetPos.y -= adjustHeight;

                if (!fly) {

                    if (targetPos.y > maxMoveHeight) {

                        targetPos.y = maxMoveHeight;

                    }

                    else if (targetPos.y < minMoveHeight) {

                        targetPos.y = minMoveHeight;

                    }

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
            transform.localScale -= sizeVector;

        } else {

            rb.useGravity = true;
            rb.isKinematic = false;
            transform.localScale += sizeVector;

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
