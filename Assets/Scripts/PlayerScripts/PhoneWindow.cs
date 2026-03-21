using UnityEngine;
using TMPro;

public class PhoneWindow : MonoBehaviour
{
    public GameObject phoneMessage;

    void Update()
    {
        if(DialogueManager.dialogueCompleted){
            phoneMessage.SetActive(Input.GetKey(KeyCode.Q));
        }
    }
}