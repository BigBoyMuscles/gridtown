using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnDrawer : MonoBehaviour {

    public int drawerSize;
    public GamePiece basePawn;
    public GamePiece rook;

    private GamePiece[] pawns;

    private GamePiece nextPawn;

	// Use this for initialization
	void Start () {
        
	}

    public GamePiece getNextPawn()
    {
        return pawns[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
