using UnityEngine;
using UnityEngine.InputSystem;

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
            
            PlayerPrefs.SetInt("HasSeenTutorial", 1);
            PlayerPrefs.Save();
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
}
