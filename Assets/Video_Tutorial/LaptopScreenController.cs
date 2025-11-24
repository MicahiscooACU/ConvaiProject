using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class LaptopScreenController : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject controlButtonCanvas;
    public GameObject videoDisplayCanvas;
    public VideoPlayer videoPlayer;

    public Button playButton;
    public Button pauseButton;
    public Button restartButton;        

    void Start()
    {
     
        controlButtonCanvas.SetActive(true);


        videoDisplayCanvas.SetActive(false);


        SetButtonStates(false); 


        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(PlayVideo);

        pauseButton.onClick.RemoveAllListeners();
        pauseButton.onClick.AddListener(PauseVideo);


        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartVideo);
    }


    private void SetButtonStates(bool isPlaying)
    {

        playButton.interactable = !isPlaying;


        pauseButton.interactable = isPlaying;


        restartButton.interactable = true;
    }



    public void PlayVideo()
    {
        videoDisplayCanvas.SetActive(true);
        videoPlayer.Play();


        SetButtonStates(true);
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();


        SetButtonStates(false);
    }


    public void RestartVideo()
    {

        videoPlayer.Stop();


        videoDisplayCanvas.SetActive(true);
        videoPlayer.Play();


        SetButtonStates(true);
    }


    public void StopVideo()
    {
        videoPlayer.Stop();
        videoDisplayCanvas.SetActive(false);


        SetButtonStates(false);
    }

    void Update()
    {

        if (videoPlayer.isPrepared && videoPlayer.time >= videoPlayer.clip.length && videoPlayer.isPlaying)
        {
            StopVideo();
        }
    }
}
