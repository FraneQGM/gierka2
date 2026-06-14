using UnityEngine;
using System.Collections;

public class PhoneNotification : MonoBehaviour
{
    public GameObject phoneMark;

    private static bool initialized = false;

    void Start()
    {
        if (initialized)
        {
            phoneMark.SetActive(false);
            return;
        }

        initialized = true;

        phoneMark.SetActive(true);
        StartCoroutine(PlaySoundWithDelay());
    }

    public void HideMark()
    {
        phoneMark.SetActive(false);
    }

    IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        soundManager.instance.PlayPhoneNotification();
    }
}