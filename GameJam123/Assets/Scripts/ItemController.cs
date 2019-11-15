using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public Transform player;
    public Transform camera;

    Rigidbody rb;

    bool pickedUp;
    bool adjustView;

    Vector3 targetPos;

    float speed = 15f;
    float maxMoveDistance = 2.5f;
    float minMoveDistance = 2f;
    float maxMoveHeight = 4f;
    float minMoveHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {

        pickedUp = false;
        adjustView = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (pickedUp) {

            rb.useGravity = false;
            rb.isKinematic = true;

            Plane plane = new Plane(Vector3.up,transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hit = 0f;

            if (plane.Raycast(ray, out hit)) {

                if (hit > maxMoveDistance) {

                    hit = maxMoveDistance;

                } else if (hit < minMoveDistance) {

                    hit = minMoveDistance;

                }

                targetPos = ray.GetPoint(hit);

                if (targetPos.y > maxMoveHeight) {

                    targetPos.y = maxMoveHeight;

                } else if (targetPos.y < minMoveHeight) {

                    targetPos.y = minMoveHeight;

                }

            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        } else {

            rb.useGravity = true;
            rb.isKinematic = false;

        }

    }

    public void pickUp_drop() {

        pickedUp = !pickedUp;

    }
}
