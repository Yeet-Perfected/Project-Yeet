using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;

    private Rigidbody rb;


    // Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Player Movement

        /*if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -1) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime, Space.World);*/

        if (Input.GetKey(KeyCode.W))
            rb.MovePosition(transform.position + (Vector3.forward * movementSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(transform.position + (Vector3.back * movementSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.A))
            rb.MovePosition(transform.position + (Vector3.left * movementSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.D))
            rb.MovePosition(transform.position + (Vector3.right * movementSpeed * Time.deltaTime));

    }

    void Update()
    {
        // Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray melee = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(melee, out hitInfo, 2f))
            {
                if (hitInfo.collider.gameObject.tag == "Enemy")
                {
                    hitInfo.collider.gameObject.GetComponent<Enemy>().health -= 5;
                }
                
            }

        }
    }

}
