using UnityEngine;
using UnityEngine.Video;

public class StreamingAssetsPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoFileName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
