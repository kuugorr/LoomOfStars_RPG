using UnityEngine;

[CreateAssetMenu(fileName = "NewRune", menuName = "ARPG/Rune")]
public class RuneData : ScriptableObject
{
    public string runeName;
    [TextArea] public string description;
    public StatModifier[] modifiers;
}
