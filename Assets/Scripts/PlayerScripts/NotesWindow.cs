using UnityEngine;
using TMPro;

public class NotesWindow : MonoBehaviour
{
    public GameObject notesPanel;

    void Update()
    {
        notesPanel.SetActive(Input.GetKey(KeyCode.Tab));
    }
}