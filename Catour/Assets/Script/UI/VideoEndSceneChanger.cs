using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer component not found.");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if(SceneManager.GetActiveScene().buildIndex != 7)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }
}
