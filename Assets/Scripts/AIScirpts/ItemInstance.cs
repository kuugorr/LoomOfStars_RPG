using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemData data;
    public int durability;
    public List<RuneData> sockets;

    public ItemInstance(ItemData d)
    {
        data = d;
        durability = 100;
        sockets = new List<RuneData>(d.socketCount);
        for (int i = 0; i < d.socketCount; i++) sockets.Add(null);
    }

    public float GetStatValue(string stat)
    {
        float baseVal = 0f;
        if (data.baseModifiers != null)
        {
            foreach (var m in data.baseModifiers)
                if (m.stat == stat) baseVal += m.value;
        }
        if (sockets != null)
        {
            foreach (var r in sockets)
            {
                if (r == null) continue;
                foreach (var m in r.modifiers)
                    if (m.stat == stat) baseVal += m.value;
            }
        }
        return baseVal;
    }
}
