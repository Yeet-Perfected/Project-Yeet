using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 75;
    public int health = 75;
    public bool brainless = false;
    public float movementSpeed;

    public Slider healthBar;
    public Canvas canvas;

    private GameObject player;
    private bool seesPlayer = false;

    public bool canSeePlayer()
    {
        return this.seesPlayer;
    }
    public void basicMovement()
    {
        Vector3 playerPos = player.transform.position;
        if (Vector3.Distance(player.transform.position, transform.position) > 7)
        {
            seesPlayer = false;
            return;
        }
        if (Vector3.Dot(transform.forward, player.transform.position - transform.position) < 0)
        {
            seesPlayer = false;
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
        targetRotation.x = 0;
        targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        seesPlayer = true;
    }

    public void setHealth(int h)
    {
        this.health = h;
    }

    public void reduceHealth(int h)
    {
        this.health -= h;
        float healthPercent = ((float)this.health / maxHealth);
        healthBar.value = healthPercent;
    }

    private void debuggingEnemy()
    {
        Debug.DrawLine(transform.position, player.transform.position);
        Debug.DrawLine(transform.position, transform.forward + transform.position);
    }

    void Start()
    {
        player = GameObject.Find("Player Holder/Player");
    }

    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(cameraPos - canvas.transform.position);
        canvas.transform.rotation = Quaternion.Slerp(canvas.transform.rotation, targetRotation, 10f * Time.deltaTime);

        basicMovement();
        debuggingEnemy();

        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
