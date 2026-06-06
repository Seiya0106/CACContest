public class TutorialButton : BaseButton, ISceneLoader
{
    protected override void OnExcute()
    {
        LoadAnyScene("Tutorial");
    }

    public void LoadAnyScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
