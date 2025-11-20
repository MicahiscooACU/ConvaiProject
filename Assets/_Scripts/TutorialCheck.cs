using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialCheck : MonoBehaviour
{
    public bool canSkip = false;

    private void Awake()
    {
        
        if (PlayerPrefs.HasKey("HasSeenTutorial"))
        {
            canSkip = true;
        }
        else
        {
            
            
            canSkip = false;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("HasSeenTutorial"))
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                PlayerPrefs.DeleteKey("HasSeenTutorial");
                PlayerPrefs.Save();
                canSkip = false;
            }
        }
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene(2);
    }
}
