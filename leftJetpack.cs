using UnityEngine;
using System.Collections;

public class leftJetpack: MonoBehaviour {
	
	float yforce;
	public float forceMult = 100f;
	Vector3 forces = new Vector3(0.0f, 0.0f, 0.0f);

	float xangle,yangle,zangle;
	
	// Use this for initialization
	void Start () {
		
	}

//	void OnGUI() {
//		GUI.skin.label.fontSize = 20;
//		GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
//		           "x angle: " + xangle +
//		           "y angle: " + yangle +
//		           "z angle: " + zangle
//		 );
//	}
	
	// Update is called once per frame
	void FixedUpdate () {

		yforce = Input.GetAxis("Vertical");

		if (Input.GetKey(KeyCode.LeftShift)) {
			forces.Set(new_x: 0.0f, new_y: 5, new_z: 0.0f);
			GetComponent<Rigidbody>().AddRelativeForce(forces * Time.deltaTime * forceMult);
		}
		
	}

	void LateUpdate() {

	}
}

