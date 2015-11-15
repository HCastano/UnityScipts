using UnityEngine;
using System.Collections;

public class rightJetpack : MonoBehaviour {

	float yforce;
	public float forceMult = 100f;
	Vector3 forces = new Vector3(0.0f, 0.0f, 0.0f);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		yforce = Input.GetAxis("Vertical");

		
		if (Input.GetKey(KeyCode.RightShift)) {
			forces.Set(new_x: 0.0f, new_y: 5, new_z: 0.0f);
			GetComponent<Rigidbody>().AddRelativeForce(forces * Time.deltaTime * forceMult);
		}
		
	}
}