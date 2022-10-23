using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTypingAnimation : MonoBehaviour
{
	public TextMeshProUGUI txt;
	public string story;
	public bool animPlaying;
	public float textSpeed = 0.125f;

	void Awake()
	{
		txt = GetComponent<TextMeshProUGUI>();
		story = txt.text;
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
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}



}
