using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;
    public int maxHealth = 130;
    public int health = 130;

    public Slider healthBar;
    public Image imageSelected;

    public Sprite bionicArm;
    public Sprite placeHolder;
    public Sprite[] sprites = new Sprite[2];

    private Rigidbody rb;


    // Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sprites[0] = bionicArm;
        sprites[1] = placeHolder;
    }

    void FixedUpdate()
    {
        // Player Movement

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && Inventory.inventory[0].isEquipped())
        {
            Ray melee = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(melee, out hitInfo, 2f))
            {
                if (hitInfo.collider.gameObject.tag == "Enemy")
                {
                    if (hitInfo.collider.gameObject.GetComponent<Enemy>().canSeePlayer())
                    {
                        hitInfo.collider.gameObject.GetComponent<Enemy>().reduceHealth(20);
                    }
                    else
                    {
                        hitInfo.collider.gameObject.GetComponent<Enemy>().reduceHealth(100);
                    }
                    
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && Inventory.inventory[1].isEquipped())
        {
            Debug.Log("Worked!");
        }

        // Player Invetory Select
        findAndEquip();

        // Player health
        if (this.health <= 0)
        {

        }
    }


    // Player Methods

    public bool isSelected(int index)
    {
        return Input.GetKeyDown(KeyCode.Alpha1 + index) && Inventory.inventory[index].isInInventory();
    }

    public void findAndEquip()
    {
        for (int i = 0; i < Inventory.inventory.Length; i++)
        {
            if (isSelected(i))
            {
                Inventory.setEquiped(i);
                imageSelected.sprite = sprites[i];
                return;
            }
        }
    }

    public void reduceHealth(int h)
    {
        this.health -= h;
        float healthPercent = ((float)this.health / maxHealth);
        healthBar.value = healthPercent;
    }

    public void setHealth(int h)
    {

    }


}
