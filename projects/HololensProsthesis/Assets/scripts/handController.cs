using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VibrationType = Thalmic.Myo.VibrationType;

public class handController : MonoBehaviour {

    public float movementSpeed = 10f;
    public float scrollSpeed = 10f;
    public GameObject myo = null;
    public GameObject handPosition;
    private Vector3 offset;


    // Use this for initialization
    void Start () {
        //offset = transform.position - Camera.main.transform.position;
        //Debug.Log(offset);
        transform.position = handPosition.transform.position;
    }
	
	// Update is called once per frame
	void Update () {



        //transform.position = Camera.main.transform.localPosition + offset;
        transform.position = handPosition.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        //thalmicMyo.Vibrate(VibrationType.Short);
    }
}
