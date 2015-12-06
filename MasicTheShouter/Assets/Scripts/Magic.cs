using UnityEngine;
using System.Collections;
using System;
using LitJson;

public class Magic : MonoBehaviour {
	private const string URL_MAGIC = "http://magictheshouter.appspot.com/magic";

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
        Get(URL_MAGIC);
	}

	#region private
	private WWW Get(string url)
	{
		var www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
		return www;
	}

	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		if (www.error == null)
		{

			MagicData data = JsonMapper.ToObject<MagicData>(www.text);
			_listener.CallBack(GetMagicStatus(data.magicno));
		}
		else
		{
			Debug.Log("WWW Error: " + www.error);
		}
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

	[Serializable]
	public class MagicData
	{
		public MagicData() { }
		public int magicno;
		public int datetime;
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
