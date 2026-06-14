using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip musicClip;

    [Header("UI")]
    public Button muteButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    public Image buttonImage;

    private bool isMuted = false;
    private float pausedTime = 0f;

    void Awake()
    {
        // singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // ustaw audio
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();

        // kliknięcie przycisku
        muteButton.onClick.AddListener(ToggleMusic);

        UpdateIcon();
    }

    public void ToggleMusic()
    {
        if (!isMuted)
        {
            // zapisz moment
            pausedTime = audioSource.time;

            audioSource.Pause();
            isMuted = true;
        }
        else
        {
            // wróć do momentu
            audioSource.time = pausedTime;

            audioSource.UnPause();
            isMuted = false;
        }

        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = isMuted ? soundOffIcon : soundOnIcon;
        }
    }
}