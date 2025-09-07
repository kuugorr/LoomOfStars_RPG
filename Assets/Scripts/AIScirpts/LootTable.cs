using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LootEntry
{
    public ItemData item;
    public int weight = 1;
    public int minLevel = 1;
}

public static class LootTable
{
    public static ItemData Roll(List<LootEntry> entries, int playerLevel)
    {
        var candidates = entries.Where(e => e.minLevel <= playerLevel).ToList();
        if (candidates.Count == 0) return null;
        int total = candidates.Sum(e => e.weight);
        int r = Random.Range(0, total);
        int acc = 0;
        foreach (var e in candidates)
        {
            acc += e.weight;
            if (r < acc) return e.item;
        }
        return null;
    }
}
