using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Dragon : MonoBehaviour {

	Animator animator;
	private List<GameObject> EnemyList = new List<GameObject>();

	void Start(){

		animator = gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.transform.root.gameObject.GetComponent<Ghoul>().Stop = true;
			EnemyList.Add(coll.gameObject.transform.root.gameObject);
			animator.SetTrigger ("Attack");
		}

	}
	void EnemyKill(){
		Debug.Log ("EnemyKill");
		EnemyList.ForEach (enemy => Destroy (enemy));
		EnemyList.Clear ();
	}
}
