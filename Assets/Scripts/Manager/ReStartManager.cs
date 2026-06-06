using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReStartManager : MonoBehaviour, ISceneLoader
{
    private InputAction restartAction;

    void Awake()
    {
        // リスタートアクションの登録
        restartAction = new InputAction("Restart", binding: "<Keyboard>/r");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// オブジェクトが有効になったときの処理
    /// </summary>
    private void OnEnable()
    {
        // リスタートアクションの有効化とイベント登録
        restartAction.Enable();
        restartAction.performed += OnReStartPerformed;
    }

    /// <summary>
    /// リスタートアクションが実行されたときの処理
    /// </summary>
    /// <param name="context"></param>
    private void OnReStartPerformed(InputAction.CallbackContext context)
    {
        LoadAnyScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 現在のシーンをロードして、リスタートする処理
    /// </summary>
    public void LoadAnyScene(string sceneName)
    {
        sceneName = SceneManager.GetActiveScene().name; // 現在のシーン名を取得
        SceneManager.LoadScene(sceneName);
    }
}
