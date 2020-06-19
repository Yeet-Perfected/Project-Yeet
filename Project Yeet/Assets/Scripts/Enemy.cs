using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 75;
    public int health = 75;
    public bool brainless = false;

    public Slider healthBar;
    public Canvas canvas;

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

    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(cameraPos - canvas.transform.position);
        canvas.transform.rotation = Quaternion.Slerp(canvas.transform.rotation, targetRotation, 10f * Time.deltaTime);


        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
