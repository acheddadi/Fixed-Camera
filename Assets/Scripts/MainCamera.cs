using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        mainCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
