using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]

public class CameraTrigger : MonoBehaviour
{
    Camera mainCamera;
    Camera triggerCamera;

	// Use this for initialization
	void Start ()
    {
        triggerCamera = GetComponent<Camera>();
        triggerCamera.enabled = false;
        mainCamera = Camera.main;
	}

    private void OnTriggerEnter()
    {
        Debug.Log("Entered camera trigger");
        if (mainCamera.enabled)
        {
            mainCamera.enabled = false;
            triggerCamera.enabled = true;
        }
        else
        {
            Camera oldTrigger = Camera.current;
            oldTrigger.enabled = false;
            triggerCamera.enabled = true;
        }
    }

    private void OnTriggerExit()
    {
        if (triggerCamera.enabled)
        {
            Debug.Log("Left camera trigger");
            triggerCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
