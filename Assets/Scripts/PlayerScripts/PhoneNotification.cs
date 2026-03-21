using UnityEngine;
using System.Collections;

public class PhoneNotification : MonoBehaviour
{
    public GameObject phoneMark;

    public static bool phoneNotification;

    private bool previousState;
    private bool soundPlayed = false;

    void Update()
    {
        bool currentState = DialogueManager.dialogueCompleted && phoneNotification;

        phoneMark.SetActive(currentState);

        // wykrycie pojawienia się
        if (currentState && !previousState && !soundPlayed)
        {
            StartCoroutine(PlaySoundWithDelay());
            soundPlayed = true;
        }

        // reset gdy zniknie
        if (!currentState)
        {
            soundPlayed = false;
        }

        previousState = currentState;
    }

    IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // 0.5 sekundy
        soundManager.instance.PlayPhoneNotification();
    }
}