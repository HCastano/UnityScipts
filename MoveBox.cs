using UnityEngine;
using System.Collections;
using System.Resources;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;


public class MoveBox : MonoBehaviour
{
	public GameObject myo = null;
    float moveSpeed = 0f;
    float moveAccel = 6.0f;

    // Use this for initialization
    void Start()
    {


    }
	//private Pose _lastPose = Pose.Unknown;


    // Update is called once per frame
    void Update()
    {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        //a = v/t
        //v = a * t 

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (thalmicMyo.pose==Pose.WaveIn) moveSpeed += moveAccel * Time.deltaTime;
            

            if (thalmicMyo.pose==Pose.WaveOut) moveSpeed -= moveAccel * Time.deltaTime;

            
        
    }

  
}
