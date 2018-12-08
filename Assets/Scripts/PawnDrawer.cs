using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnDrawer : MonoBehaviour {

    public int drawerSize;
    public GamePiece basePawn;
    private GamePiece[] pawns;

    private GamePiece nextPawn;

	// Use this for initialization
	void Start () {
        pawns = new GamePiece[drawerSize];
        
        for(int i = 0; i < pawns.Length; i++)
        {
            pawns[i] = GamePiece.Instantiate(basePawn);
        }
        
	}

    public GamePiece getNextPawn()
    {
        return pawns[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
