using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public GameObject FireBall_1;
	private GameObject Player;
	private Vector3 MovDir;//飛ばす方向
	public float Speed;//速さ調整
	public int AttackPoint;
	public AudioClip FireSE;
	AudioSource audioSource;
	
	void Start () {
	
		Player = GameObject.Find ("PlayerCamera");
		MovDir = Player.transform.position - Player.transform.FindChild ("CameraPivot").gameObject.transform.position;
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (FireSE);
	
	}

	void OnTriggerEnter(Collider coll){

		Instantiate (FireBall_1, transform.position, new Quaternion (0, 0, 0, 1));

		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.GetComponent<HitDamage>().Damage = AttackPoint;
		}


		Destroy (gameObject);

	}

	void Update () {

		transform.Translate (MovDir.normalized * Time.deltaTime * Speed);
	
	}
}
