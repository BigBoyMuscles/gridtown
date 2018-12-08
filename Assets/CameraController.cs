using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Board board;
    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
       
    }
	
	// Update is called once per frame
	void Update () {

        Camera.main.orthographicSize = (float)board.boardSize / 1.6f;
    }
}
