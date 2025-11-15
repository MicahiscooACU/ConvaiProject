using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void clickedButton()
    {
        SceneManager.LoadScene(0);
    }
}
