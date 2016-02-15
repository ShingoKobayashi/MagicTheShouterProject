using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour, Magic.MagicListener{

	public GameObject Fire;
	public GameObject Thunder;
	public GameObject Player;
	public GameObject PlayerPivot;
	public GameObject MagicFormation; 
	public GameObject Dragon;
	public GameObject MagicFormation_Dragon;
	public GameObject DragonParticle;
	private Vector3 LookTo;

	RaycastHit hit;
	
	private Magic magic;
	
	void Start () {
		magic = GetComponent<Magic>();
		magic.Init(this);
	}

	void Update () {
		RequestMagic();

		LookTo = Player.transform.position - PlayerPivot.transform.position;

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			procKey (Magic.MNo.FireBall);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			procKey (Magic.MNo.ThunderStorm);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			procKey(Magic.MNo.Dragon);
		}
	}

	private void procKey(Magic.MNo mno){
		switch (mno) {
		case Magic.MNo.FireBall:
			Instantiate (Fire,Player.transform.position + LookTo.normalized * 2, new Quaternion(0,0,0,1));
			break;
		case Magic.MNo.ThunderStorm:
			if (Physics.Raycast(Player.transform.position,LookTo.normalized,out hit)){
				if(hit.collider.tag == "Ground"){
					Instantiate(Thunder,hit.point,new Quaternion(0,0,0,1f));
				}
			}
			break;
		case Magic.MNo.FinalDragoon:
		case Magic.MNo.Dragon:
			DragonEffectAppear(true);
			Invoke ("DeleteDragon",15f);
			break;
		}
	}

	void DeleteDragon(){
		Dragon.SetActive (false);
		DragonEffectAppear (false);
	}

	void DragonEffectAppear(bool active){

		MagicFormation_Dragon.SetActive(active);
		DragonParticle.SetActive(active);
		if (active) {
			Invoke ("ActiveDragon", 1f);
		}

	}
	void ActiveDragon(){
		Dragon.SetActive (true);
	}
	
	public void RequestMagic()
	{
		magic.RequestMagic();
	}
	
	public void CallBack(Magic.Status magicStatus)
	{
		switch(magicStatus.No){
		case Magic.MNo.Ready:
			MagicFormationAppear(true);
			break;
		case Magic.MNo.Cancel:
			MagicFormationAppear(false);
			break;
		case Magic.MNo.None:
			break;
		default:
			procKey(magicStatus.No);
			MagicFormationAppear(false);
			break;
		}
	}

	void MagicFormationAppear(bool active){

		MagicFormation.SetActive (active);

	}
}
