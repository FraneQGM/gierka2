using System.Collections.Generic;
using UnityEngine;

public static class DialogueProgress
{
    private static HashSet<string> completedDialogues = new HashSet<string>();

    public static void CompleteDialogue(string id)
    {
        if (!completedDialogues.Contains(id))
        {
            completedDialogues.Add(id);
            Debug.Log("Ukończono dialog: " + id);
        }
    }

    public static bool IsCompleted(string id)
    {
        return completedDialogues.Contains(id);
    }

    public static bool AreRequirementsMet(string[] requirements)
    {
        if (requirements == null || requirements.Length == 0)
            return true;

        foreach (var req in requirements)
        {
            if (!completedDialogues.Contains(req))
                return false;
        }

        return true;
    }
}