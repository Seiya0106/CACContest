using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NextStageManager : MonoBehaviour
{
    [SerializeField] private GameClearManager gameClearManager;
    private InputAction nextStageAction;
    [SerializeField] private string nextStageName;

    void Awake()
    {
        // 次のステージアクションの登録
        nextStageAction = new InputAction("NextStage", binding: "<Keyboard>/enter");
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
        // 次のステージアクションの有効化とイベント登録
        nextStageAction.Enable();
        nextStageAction.performed += OnNextStagePerformed;
    }

    private void OnNextStagePerformed(InputAction.CallbackContext context)
    {
        if (gameClearManager.IsGameCleared)
        {
            SceneManager.LoadScene(nextStageName);
        }
    }
}
