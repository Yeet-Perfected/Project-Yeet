using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 75;
    public bool brainless = false;

    public void setHealth(int h)
    {
        this.health = h;
    }

    public void reduceHealth(int h)
    {
        this.health -= h;
    }

    void Update()
    {
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
