using UnityEngine;
using System;

public enum ItemRarity { Common, Uncommon, Rare, Epic, Legendary }

[CreateAssetMenu(fileName = "NewItem", menuName = "ARPG/Item")]
public class ItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public ItemRarity rarity;
    public Sprite icon;
    public GameObject worldPrefab;
    public int itemLevel = 1;
    public int socketCount = 0;
    public StatModifier[] baseModifiers;
}

[Serializable]
public struct StatModifier
{
    public string stat;
    public float value;
    public bool additive; // true: add, false: multiply
}
