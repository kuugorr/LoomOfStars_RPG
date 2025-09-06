using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSkillNode", menuName = "ARPG/SkillNode")]
public class SkillNode : ScriptableObject
{
    public string nodeId;
    public string nodeName;
    [TextArea] public string description;
    public int cost = 1;
    public List<SkillNode> prerequisites = new List<SkillNode>();
    public StatModifier[] modifiers;
}
