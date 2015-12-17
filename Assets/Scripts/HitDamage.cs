using UnityEngine;
using System.Collections;

public class HitDamage : MonoBehaviour {

	public int DamagePower = 1;//ダメージ倍率
	public int Damage;
	public GameObject Parent;
	public string TriggerName;
	private bool AlreadyDie = false;
	private int RandomNum;
	public AudioClip[] EnemyVoice = new AudioClip[5];
	AudioSource audioSource;

	void Start(){
		audioSource = Parent.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(){
		if (Damage >= 1) {
			Parent.GetComponent<EnemyManager> ().HP -= Damage * DamagePower;
			if (Parent.GetComponent<EnemyManager> ().HP <= 0 && !AlreadyDie) {
				Parent.GetComponent<Animator> ().SetTrigger ("Die");
				audioSource.PlayOneShot(EnemyVoice[0]);
				AlreadyDie = true;
				Invoke ("DestroyMe", 3f);
			} else {
				Parent.GetComponent<Animator> ().SetTrigger (TriggerName);
				RandomNum = Random.Range(1,5);
				audioSource.PlayOneShot(EnemyVoice[RandomNum]);
			}
		} 
	}

	void DestroyMe(){

		ScoreManager.IncrementKilledNum();
		if (ScoreManager.KilledAllEnemy()) {
			ScoreManager.Display ();
		}
		AlreadyDie = false;
		Destroy (Parent);
	}
}
