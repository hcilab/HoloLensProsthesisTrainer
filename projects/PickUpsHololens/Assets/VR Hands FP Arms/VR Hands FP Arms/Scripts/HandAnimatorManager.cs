using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Pose = Thalmic.Myo.Pose;

public class HandAnimatorManager : MonoBehaviour
{
	public StateModel[] stateModels;
    public GameObject myo = null;
    public float animSpeed = 0.1f;
    public bool isAttached = false;


    Animator handAnimator;

    private Pose _lastPose = Pose.Unknown;

    // Use this for initialization

    void Start ()
	{
		handAnimator = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update ()
	{
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (isAttached && (thalmicMyo.pose == Pose.WaveIn))
        {
            handAnimator.speed = 0;
        }

        else if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;

            if (thalmicMyo.pose == Pose.WaveIn)
            {
                handAnimator.SetBool("waveIn", true);
                HandOpen();
            }

            else
            {
                handAnimator.SetBool("waveIn", false);
            }

            if (thalmicMyo.pose == Pose.Rest)
            {
                HandRest();
            }

            if (thalmicMyo.pose == Pose.WaveOut)
            {
                handAnimator.SetBool("waveOut", true);
                HandClose();
            }

            else
            {
                handAnimator.SetBool("waveOut", false);
            }
            
        }
	}

	void TurnOnState (int stateNumber)
	{
		foreach (var item in stateModels) {
			if (item.stateNumber == stateNumber && !item.go.activeSelf)
				item.go.SetActive (true);
			else if (item.go.activeSelf)
				item.go.SetActive (false);
		}
	}

    void HandRest()
    {
        handAnimator.speed = 0f;
    }

    void HandOpen()
    {
        handAnimator.speed = 1;
        handAnimator.SetFloat("Speed", 1f * animSpeed);
    }

    void HandClose()
    {
        handAnimator.speed = 1;
        handAnimator.SetFloat("Speed", -1f * animSpeed);
    }
}

[Serializable]
public class StateModel
{
	public int stateNumber;
	public GameObject go;
}
