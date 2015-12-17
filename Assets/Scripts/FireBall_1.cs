using UnityEngine;
using System.Collections;

public class FireBall_1 : MonoBehaviour {
	
	void Start () {

		Invoke ("DestroyMe", 1f);
	
	}
	void DestroyMe(){
		Destroy (gameObject);
	}
}
