using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LeaveTutorial : MonoBehaviour
{
  
    public float counter = 0;
    [SerializeField] private float spacebarCounter = 0;
    public GameObject text;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HasSeenTutorial"))
        {
            text.SetActive(true);
            
        }
        else
        {
            text.SetActive(false);
        }
    }
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 276)
        {
            PlayerPrefs.SetInt("HasSeenTutorial", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }

        if (spacebarCounter < 3 && Keyboard.current.spaceKey.isPressed && PlayerPrefs.HasKey("HasSeenTutorial"))
        {
            spacebarCounter += Time.deltaTime;
        }
        else if (spacebarCounter < 3 && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            spacebarCounter = 0;
        }
        if (spacebarCounter >= 3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
