using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Movement player;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "HP: " + player.health.ToString();
    }
}