using UnityEngine;
using System.Collections;

public class MagicFormation : MonoBehaviour {

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			gameObject.GetComponent<Animator> ().SetTrigger ("Close");
			Invoke ("DestroyMe",1f);
		}
	}
	void DestroyMe(){
		Destroy (gameObject);
	}
}
