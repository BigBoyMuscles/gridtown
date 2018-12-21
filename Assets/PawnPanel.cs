using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PawnPanel : MonoBehaviour {

    public bool blue;

    public int x;
    public int y;
    public int boardSize;

    public Text pawnTitle;
    public Text pawnHealth;
    public Text pawnPower;
    public Text pawnSpeed;

    [SerializeField]
    private GamePiece SelectedPawn;

    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {

        rend = this.gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();



        if (blue)
        {
            transform.position = new Vector3((9 * 1.125f) - (boardSize / 2), 0, 0);
        }else
        {
            transform.position = new Vector3((-2 * 1.125f) - (boardSize / 2), 0, 0);            
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (blue)
        {
            transform.position = new Vector3((9 * 1.125f) - (boardSize / 2), 0, 0);
        }
        else
        {
            transform.position = new Vector3((-2 * 1.125f) - (boardSize / 2), 0, 0);
        }


    }

    public void setSelectedPawn(GamePiece p)
    {
        SelectedPawn = p;

        // Get sprite renderer of child instead of main renderer
        rend.sprite = p.GetComponent<SpriteRenderer>().sprite;
        
        //updatePawnPanel();


    }

    public void updatePawnPanel()
    {
        //PawnStats stat = SelectedPawn.GetComponent<PawnStats>();

        //pawnTitle.text = stat.title;

        //pawnTitle.text = SelectedPawn.GetComponent<PawnStats>().title;

        //pawnHealth.text = stat.health.ToString();
        //pawnPower.text = stat.power.ToString();
        //pawnSpeed.text = stat.speed.ToString();
    }

    public void toggleTeam()
    {
        if(blue)
        {
            blue = false;
        } else
        {
            blue = true;
        }
    }

    public void clearSelectedPawn()
    {
        SelectedPawn = null;
        rend.sprite = null;
    }
}
