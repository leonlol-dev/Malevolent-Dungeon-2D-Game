using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }
}
