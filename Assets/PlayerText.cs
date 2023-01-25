using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerText : MonoBehaviour
{
    //This script handles the text that appears on the players head after an event. E.g. upgrade gained.

    public Transform origin;
    public GameObject textPrefab;


    public void InstantiateText(string text)
    {
        GameObject instantiate = Instantiate(textPrefab, origin);
        instantiate.GetComponent<FloatingText>().SetText(text);

    }

}
