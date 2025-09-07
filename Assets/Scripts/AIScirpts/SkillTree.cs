using UnityEngine;
using System.Collections.Generic;

public class SkillTree : MonoBehaviour
{
    public List<SkillNode> allNodes = new List<SkillNode>();
    public List<SkillNode> unlocked = new List<SkillNode>();
    public int availablePoints = 0;

    public bool CanUnlock(SkillNode node)
    {
        if (unlocked.Contains(node)) return false;
        foreach (var pre in node.prerequisites)
            if (!unlocked.Contains(pre)) return false;
        return availablePoints >= node.cost;
    }

    public bool Unlock(SkillNode node)
    {
        if (!CanUnlock(node)) return false;
        availablePoints -= node.cost;
        unlocked.Add(node);
        ApplyNodeModifiers(node);
        return true;
    }

    private void ApplyNodeModifiers(SkillNode node)
    {
        // In a real project, you'd apply node.modifiers to player's stats
        Debug.Log($"Unlocked node: {node.nodeName}");
    }
}
