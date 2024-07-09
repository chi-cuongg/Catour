using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private SceneChange scene;
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

        scene = FindAnyObjectByType<SceneChange>();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if(SceneManager.GetActiveScene().buildIndex != 6)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else{ 
            SceneManager.LoadSceneAsync(0);
            if(scene != null) scene.Reset();
        }
    }
}
