using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int gold;

    private PlayerAudioHandler audioHandler;

    private void Awake()
    {
        audioHandler = GetComponent<PlayerAudioHandler>();
    }

    public void ReceiveGold(int _gold)
    {
        audioHandler.coinCollectSound();
        gold += _gold;
    }

    
}
