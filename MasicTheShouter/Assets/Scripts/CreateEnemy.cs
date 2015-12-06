using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

	public GameObject Ghoul;
	public float CreateTimeMin;
	public float CreateTimeMax;
	private bool NowWait = false;
	private float RandomFloat;
	public float PositionRangeMin;
	public float PositionRangeMax;
	public int x = 0;
	public int z = 0;

	void Start () {
	
	}

	void Update () {

		if (!NowWait) {
			Invoke("CreateInstance",Random.Range(CreateTimeMin,CreateTimeMax));
			NowWait = true;
		}
	
	}

	void CreateInstance(){
		if (ScoreManager.ReachedMaxEnemy()) {
			return;
		}

		ScoreManager.IncrementAppearNum ();
		RandomFloat = Random.Range (PositionRangeMin, PositionRangeMax);
		Instantiate (Ghoul, new Vector3(gameObject.transform.position.x + RandomFloat * x,gameObject.transform.position.y,gameObject.transform.position.z + RandomFloat * z), new Quaternion(0,0,0,1));
		NowWait = false;
	}
}
