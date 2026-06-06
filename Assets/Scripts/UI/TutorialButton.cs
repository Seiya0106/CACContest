using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class TutorialButton : BaseButton, ISceneLoader
{
    protected override void OnExcute()
    {
        LoadAnyScene("Tutorial");
    }

    public void LoadAnyScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName, 0.1f));
    }

    // 遅延を設定してシーンをロードするコルーチン
    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
