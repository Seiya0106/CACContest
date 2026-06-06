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
}
