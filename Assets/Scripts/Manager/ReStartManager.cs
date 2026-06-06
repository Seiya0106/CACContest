using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReStartManager : MonoBehaviour
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
        LoadCurrentScene();
    }

    /// <summary>
    /// 現在のシーンをロードして、リスタートする処理
    /// </summary>
    private void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
