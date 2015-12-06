using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text;

public class View : MonoBehaviour, Magic.MagicListener
{
	public Text viewText;
	private Magic magic;
	
	void Start () {
		magic = GetComponent<Magic>();
		magic.Init(this);
		InvokeRepeating("RequestMagic", 1, 1);
	}

	public void RequestMagic()
	{
		magic.RequestMagic();
    }

	public void CallBack(Magic.Status magicStatus)
	{
		var textSb = new StringBuilder();
		textSb.Append(magicStatus.No.ToString());
		textSb.Append(Environment.NewLine);
		textSb.Append(magicStatus.Level.ToString());
		textSb.Append(Environment.NewLine);
		textSb.Append(magicStatus.Type.ToString());
		textSb.Append(Environment.NewLine);
		textSb.Append(magicStatus.Damage.ToString());
		viewText.text = textSb.ToString();
	}
}
