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

    private void OnEnable()
    {
        // リスタートアクションの有効化とイベント登録
        restartAction.Enable();
        restartAction.performed += OnReStartPerformed;
    }

    private void OnReStartPerformed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);;
    }
}
