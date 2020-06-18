using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;
    public int maxHealth = 130;
    public int health = 130;

    public RectTransform healthBar;
    public RectTransform canvas;
    private float barMaxX;
    private float barMinX;

    private Rigidbody rb;



    // Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        barMaxX = healthBar.offsetMax.x;
        barMinX = healthBar.offsetMin.x;
    }

    void FixedUpdate()
    {
        // Player Movement

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

        // Player attack

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

        // Player health
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.ReduceHealth(5);
        }
        


        if (this.health <= 0)
        {

        }
    }


    // Player Methods

    public void ReduceHealth(int h)
    {
        this.health -= h;
        float healthPercent = 1 - ((float)this.health / maxHealth);
        Debug.Log(healthPercent);
        float barSize = healthPercent * (canvas.sizeDelta.x + barMaxX - barMinX);
        Debug.Log(-barSize + barMaxX);
        healthBar.offsetMax = new Vector2(-barSize + barMaxX, healthBar.offsetMax.y);
    }

    public void setHealth(int h)
    {

    }


}
