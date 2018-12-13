using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnStats : MonoBehaviour {

    public int health = 1;
    public int power = 1;
    public int speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void setStats(int h, int p, int s)
    {
        health = h;
        power = p;
        speed = s;
    }

    public void setHealth(int h)
    {
        health = h;
    }

    public void setPower(int p)
    {
        power = p;
    }

    public void setSpeed(int s)
    {
        speed = s;
    }

    public void damage(int d)
    {
        health = health - d;
    }

    public bool isDead()
    {
        if(health <= 0)
        {
            return true;
        }

        return false;
    }
}
