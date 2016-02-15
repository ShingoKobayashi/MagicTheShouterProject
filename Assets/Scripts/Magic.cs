using UnityEngine;
using System.Collections;
using System;
using LitJson;

public class Magic : MonoBehaviour {
	public Julius_Client julius = null;

	public enum MNo
	{
		Cancel = -1,
		None = 0,
		Ready = 1000,
		FireBall = 1001,
		Dragon = 1002,
		Begiragon = 1003,
		Megante = 1004,
		IceStorm = 1005,
		Raidein = 1006,
		ThunderStorm = 1007,
		ScrewWave = 1008,
		BigWave = 1009,
		Gigadoriru = 1010,
		Kurushio = 1011,
		TigerBazooka = 1012,
		Paropunte = 1013,
		SJK = 1014,
		FinalDragoon = 1015,
		RocknRoll = 1016,
		RainField = 1017,
	}

	public enum MType
	{
		None,
		Fire,
		Water,
		Wind,
		Soil,
		Thunder,
	}

	MagicListener _listener;
	public void Init(MagicListener listener)
	{
		_listener = listener;
	}

	public void RequestMagic()
	{
		StartCoroutine(WaitForRequest());
	}

	#region private
	private IEnumerator WaitForRequest()
	{
		if (julius != null && !String.IsNullOrEmpty(julius.Result))
		{
			var inputText = julius.Result.Trim();
			Debug.Log("inputText : " + inputText);

			var magicno = 0;
			if (int.TryParse(inputText, out magicno))
			{
				var status = GetMagicStatus(magicno);
				Debug.Log("Magic: " + status.No.ToString());

				_listener.CallBack(status);
			}
		}

		yield return null;
	}

	private Status GetMagicStatus(int magicNo)
	{
		var status = new Status() { No = (MNo)magicNo };
		switch (status.No)
		{
			case MNo.FireBall:
				status.Level = 1;
				status.Type = MType.Fire;
				status.Damage = 1;
				break;
			case MNo.Dragon:
				status.Level = 10;
				status.Type = MType.Fire;
				status.Damage = 10;
				break;
			case MNo.Begiragon:
				status.Level = 3;
				status.Type = MType.Fire;
				status.Damage = 3;
				break;
			case MNo.Megante:
				status.Level = 10;
				status.Type = MType.Fire;
				status.Damage = 20;
				break;
			case MNo.IceStorm:
				status.Level = 1;
				status.Type = MType.Water;
				status.Damage = 1;
				break;
			case MNo.Raidein:
				status.Level = 10;
				status.Type = MType.Thunder;
				status.Damage = 10;
				break;
			case MNo.ThunderStorm:
				status.Level = 1;
				status.Type = MType.Thunder;
				status.Damage = 1;
				break;
			case MNo.ScrewWave:
				status.Level = 1;
				status.Type = MType.Wind;
				status.Damage = 1;
				break;
			case MNo.BigWave:
				status.Level = 3;
				status.Type = MType.Wind;
				status.Damage = 3;
				break;
			case MNo.Gigadoriru:
				status.Level = 3;
				status.Type = MType.Soil;
				status.Damage = 3;
				break;
			case MNo.Kurushio:
				status.Level = 3;
				status.Type = MType.Water;
				status.Damage = 3;
				break;
			case MNo.TigerBazooka:
				status.Level = 3;
				status.Type = MType.Fire;
				status.Damage = 3;
				break;
			case MNo.Paropunte:
				status.Level = 10;
				status.Type = MType.None;
				status.Damage = 10;
				break;
			case MNo.SJK:
				status.Level = 20;
				status.Type = MType.Water;
				status.Damage = 20;
				break;
			case MNo.FinalDragoon:
				status.Level = 20;
				status.Type = MType.Fire;
				status.Damage = 20;
				break;
			case MNo.RocknRoll:
				status.Level = 1;
				status.Type = MType.Soil;
				status.Damage = 1;
				break;
			case MNo.RainField:
				status.Level = 1;
				status.Type = MType.Water;
				status.Damage = 1;
				break;
		}
		return status;
	}

	#endregion

	#region inner class
	public interface MagicListener
	{
		void CallBack(Status magicStatus);
	}

	public class Status
	{
		public MNo No { get; set; }
		public int Level { get; set; }
		public MType Type { get; set; }
		public int Damage { get; set; }
	}
	#endregion
}
