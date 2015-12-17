using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {
	
	private static int KilledNum = 0;
	private static int AppearNum = 0;
	private static int MaxEnemyNum = 0;

	private static bool isGameEnd = false;

	private static Canvas ResulutCanvas;
	private static Text TimeScoreText;
	private static Text KilledEnemyText;
	private static Text PerfectText;

	public int MaxEnemy;


	void Start () {
		MaxEnemyNum = MaxEnemy;
		ResulutCanvas = (UnityEngine.Canvas)GameObject.Find ("Canvas").GetComponent<Canvas>();
		TimeScoreText = (UnityEngine.UI.Text)ResulutCanvas.transform.FindChild ("TimeScore").GetComponent<Text> ();
		KilledEnemyText = (UnityEngine.UI.Text)ResulutCanvas.transform.FindChild ("KilledNum").GetComponent<Text> ();
		PerfectText = (UnityEngine.UI.Text)ResulutCanvas.transform.FindChild ("Perfect").GetComponent<Text> ();
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Display ();
		}
	}
	public static void Display(){
		if (isGameEnd) {
			return;
		}
		isGameEnd = true;

		var realtime = Time.realtimeSinceStartup;
		var min = (int)(realtime / 60);
		var sec = (int)(realtime % 60);

		ResulutCanvas.enabled = true;
		TimeScoreText.text = String.Format ("{0:D2}:{1:D2}", min, sec);
		KilledEnemyText.text = KilledNum.ToString();
		PerfectText.enabled = KilledAllEnemy();
	}

	public static bool ReachedMaxEnemy(){
		return MaxEnemyNum <= AppearNum;

	}
	public static void IncrementAppearNum(){
		AppearNum += 1;
	}
	public static void IncrementKilledNum(){
		KilledNum += 1;
	}
	public static bool KilledAllEnemy(){
		return AppearNum <= KilledNum;
	}
}
