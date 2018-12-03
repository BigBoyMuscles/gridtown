using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    //Basic stats for now
    [Header("Pawn Stats")]
    public double health;
    public int speed;
    public int strength;

    private SpriteRenderer spriteRenderer;



    //This class will hold other info about pawns, such as:
    //team ownership
    //Status Effects
    //Powerups

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        health = 3.0f;
        speed = 4;
        strength = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead())
        {
            Debug.Log("Pawn Died");
            return;
        }


	}

    private bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    }

    public void kill()
    {
        health = health - health;
    }

    // Requires calls for movement / pawn interactions


    
}
