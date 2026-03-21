using UnityEngine;

public class PhoneNotification : MonoBehaviour
{
    public GameObject phoneMark;

    public static bool phoneNotification;

    void Update()
    {
        phoneMark.SetActive(DialogueManager.dialogueCompleted && phoneNotification);
    }
}