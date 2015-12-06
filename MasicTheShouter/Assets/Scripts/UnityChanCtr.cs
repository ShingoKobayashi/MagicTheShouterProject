using UnityEngine;
using System.Collections;

public class UnityChanCtr : MonoBehaviour {

	void Start(){
		Invoke ("Death", 40f);
	}
	
	void Update () {

		transform.Translate (0, 0, 2f * Time.deltaTime);
	
	}
	void Death(){
		Destroy (gameObject);

	}
}
