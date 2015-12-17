using UnityEngine;
using System.Collections;

public class EnemyAttackField : MonoBehaviour {

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.transform.root.gameObject.GetComponent<Ghoul>().Stop = true;
			coll.gameObject.transform.root.gameObject.GetComponent<Animator>().SetTrigger("Attack");
			ScoreManager.Display();
		}
	}
}
