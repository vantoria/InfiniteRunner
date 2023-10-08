
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    private void OnVideoEnd(VideoPlayer vp){
        gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
