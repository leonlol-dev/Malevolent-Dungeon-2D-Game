using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTypingAnimation : MonoBehaviour
{
	public TextMeshProUGUI txt;
	public string visitText;

	public bool animPlaying;
	public float textSpeed = 0.125f;

	void Awake()
	{
		txt = GetComponent<TextMeshProUGUI>();
		visitText = txt.text;
		txt.text = "";
		animPlaying = false;
	}


	public void PlayAnimation()
    {
		if (!animPlaying)
		{
			animPlaying = true;
			StartCoroutine("PlayText");
		}
	}

	public void Clear()
    {
		txt.text = "";
		animPlaying = false;
    }

	IEnumerator PlayText()
	{
		foreach (char c in visitText)
		{
			txt.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}



}
