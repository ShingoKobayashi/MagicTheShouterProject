using UnityEngine;
using System.Collections;

public class Ghoul : MonoBehaviour {

	public float StayTimeMin;
	public float StayTimeMax;
	public float WalkTimeMin;
	public float WalkTimeMax;
	public float WalkSpeed;
	private bool Walk = false;
	private bool doing = false;
	public bool Stop = false;

	private GameObject Player;
//	private Vector3 ToPlayer;

	void Start(){

		Player = GameObject.Find ("PlayerCamera");
		transform.LookAt(new Vector3(Player.transform.position.x,0,Player.transform.position.z));
	}

	void Update () {

		if (!doing) {
			if (Walk) {
				Invoke ("ChangeState", Random.Range (WalkTimeMin, WalkTimeMax));
				doing = true;
			} else {
				Invoke ("ChangeState", Random.Range (StayTimeMin, StayTimeMax));
				doing = true;
			}
		}

		if (Walk && gameObject.GetComponent<EnemyManager>().HP >= 1 && !Stop) {
			transform.Translate (0, 0, WalkSpeed * Time.deltaTime);
//			ToPlayer = new Vector3(Player.transform.position.x - gameObject.transform.position.x,0,Player.transform.position.z - gameObject.transform.position.z);
//			transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.FromToRotation(gameObject.transform
		}
	
	}
	void ChangeState(){

		if (Walk) {
			gameObject.GetComponent<Animator>().SetBool("Walk",false);
			Walk = false;
			doing = false;
		} else {
			gameObject.GetComponent<Animator>().SetBool("Walk",true);
			Walk = true;
			doing = false;
		}
	}
}
