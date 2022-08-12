using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddUpgrade(Upgrade _upgrade, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].upgrade == _upgrade)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {

        }
    }
}


[System.Serializable]
public class InventorySlot
{
    public Upgrade upgrade;
    public int amount;
    public InventorySlot(Upgrade _ugprade, int _amount)
    {
        upgrade = _ugprade;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}


