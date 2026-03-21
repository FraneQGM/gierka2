using UnityEngine;

public class PlayerBackToLastPosition : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = SceneSwitch.lastPosition;
        }
    }
}