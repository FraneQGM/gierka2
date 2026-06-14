using UnityEngine;

public class PhoneWindow : MonoBehaviour
{
    public GameObject phoneMessage;

    private PhoneNotification phoneNotification;

    void Start()
    {
        phoneNotification = GetComponent<PhoneNotification>();
    }

    void Update()
    {
        bool isHolding = Input.GetKey(KeyCode.Q);
        phoneMessage.SetActive(isHolding);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            phoneNotification.HideMark();
        }
    }
}