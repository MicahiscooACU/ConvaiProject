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
        if (TC.canSkip)
        {
            SceneManager.LoadScene(1);
        }
       else
        {
            SceneManager.LoadScene(2);
        }
    }
}
