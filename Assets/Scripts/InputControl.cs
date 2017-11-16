using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
	private void Start()
	{
		
	}
	
	private void Update()
	{
		if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
	}
}
