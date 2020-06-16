using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;


    // Methods
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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        // Player Movement

        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -1) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime, Space.World);

    }

}
