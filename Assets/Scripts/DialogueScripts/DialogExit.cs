using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogExit : MonoBehaviour
{
    public string sceneToReturn = "Main";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToReturn);
            
        }
    }
}