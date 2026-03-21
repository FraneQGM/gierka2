using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource audioSource;
    public AudioClip phoneNotificationClip;

    void Awake()
    {
        instance = this;
    }

    public void PlayPhoneNotification()
    {
        audioSource.PlayOneShot(phoneNotificationClip);
    }
}