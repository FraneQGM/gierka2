using UnityEngine;

public class PhoneWindow : MonoBehaviour
{
    public GameObject phoneMessage;

    void Update()
    {
        if (!DialogueManager.dialogueCompleted)
        {
            phoneMessage.SetActive(false);
            return;
        }

        bool isHolding = Input.GetKey(KeyCode.Q);
        phoneMessage.SetActive(isHolding);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PhoneNotification.phoneNotification = false;
        }
    }
}