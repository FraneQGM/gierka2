using UnityEngine;
using TMPro;

public class PhoneWindow : MonoBehaviour
{
    public GameObject phoneMessage;

    void Update()
    {
        phoneMessage.SetActive(Input.GetKey(KeyCode.Q));
    }
}