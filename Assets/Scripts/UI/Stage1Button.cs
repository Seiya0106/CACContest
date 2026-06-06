public class Stage1Button : BaseButton
{
    protected override void OnExcute()
    {
        LoadAnyScene("Stage1");
    }

    public void LoadAnyScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName, 0.1f));
    }
}
