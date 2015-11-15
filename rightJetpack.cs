using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class rightJetpack : MonoBehaviour {

	float yforce;
	public float forceMult = 100f;
	Vector3 forces = new Vector3(0.0f, 0.0f, 0.0f);

    public GameObject myo = null;
    float moveSpeed = 0f;
    float moveAccel = 6.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

       // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        yforce = Input.GetAxis("Vertical");

		
		if (thalmicMyo.pose == Pose.Fist) {
			forces.Set(new_x: 0.0f, new_y: 5, new_z: 0.0f);
			GetComponent<Rigidbody>().AddRelativeForce(forces * Time.deltaTime * forceMult);
		}
		
	}
}