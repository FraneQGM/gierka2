using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip phoneNotificationClip;

    private bool isMuted = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        ApplyMute();
    }

    public void SetMute(bool mute)
    {
        isMuted = mute;
        ApplyMute();
    }

    private void ApplyMute()
    {
        if (audioSource != null)
        {
            audioSource.mute = isMuted;
        }
    }

    public void PlayPhoneNotification()
    {
        if (audioSource == null || phoneNotificationClip == null) return;
        if (isMuted) return;

        audioSource.PlayOneShot(phoneNotificationClip);
    }
}