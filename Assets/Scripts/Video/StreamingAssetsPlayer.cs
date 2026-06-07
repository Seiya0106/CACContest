using UnityEngine;
using UnityEngine.Video;

public class StreamingAssetsPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoFileName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // StreamingAssetsフォルダ内の動画ファイルのパスを設定
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        // ビデオの準備が完了したら動画を再生する
        videoPlayer.prepareCompleted += OnVideoPrepareCompleted;
        videoPlayer.Prepare();
    }

    /// <summary>
    /// ビデオの準備が完了したときの処理
    /// </summary>
    /// <param name="source"></param>
    void OnVideoPrepareCompleted(VideoPlayer source)
    {
        source.prepareCompleted -= OnVideoPrepareCompleted; // イベントの解除
        source.Play();
    }
}
