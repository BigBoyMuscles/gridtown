using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnDrawer : MonoBehaviour {

    public int drawerSize;
    public GameObject[] pawns;

	// Use this for initialization
	void Start () {
        pawns = new GameObject[drawerSize];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
