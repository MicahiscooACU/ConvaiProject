using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveTutorial : MonoBehaviour
{
    public float counter = 0;
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 276)
        {
            SceneManager.LoadScene(1);
        }
    }
}
