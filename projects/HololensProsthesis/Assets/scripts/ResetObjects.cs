using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour {

    Vector3 originalPosition;
	// Use this for initialization
	void Start () {
        originalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("q"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.localPosition = originalPosition;
            GetComponent<Rigidbody>().isKinematic = false;
        }

	}
}
