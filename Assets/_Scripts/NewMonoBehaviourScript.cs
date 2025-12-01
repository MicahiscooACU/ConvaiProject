using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    TutorialCheck TC;

    private void Start()
    {
        TC = GetComponent<TutorialCheck>();
    }
    public void clickedButton() //load main menu
    {
        SceneManager.LoadScene(0);
    }

    public void clickedButton2() //load office
    {
        LoadingScreen LS = FindAnyObjectByType<LoadingScreen>();
        if (LS != null)
        {
            LS.LoadLevel();
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void resetscene()
    {
        SceneManager.LoadScene(1);
    }
}
