using UnityEngine;
using System.Collections;

public class Thunder : MonoBehaviour {

	public int AttackPoint;
	public AudioClip ThunderSE;
	AudioSource audioSource;

	void Start(){

		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (ThunderSE);
	}

	void OnTriggerEnter(Collider coll){
		
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.GetComponent<HitDamage>().Damage = AttackPoint;
		}
		Invoke("DestroyMe",3f);
	}
	void DestroyMe(){
		Destroy (gameObject);
	}
}
