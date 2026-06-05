using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 moveInput;
    [SerializeField] private Rigidbody2D playerRigidbody;
    private bool isGrounded = true;
    private bool jumpPressed = false;
    void Awake()
    {
        // 移動アクションの登録
        moveAction = new InputAction("Move");
        moveAction.AddCompositeBinding("2DVector")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.AddCompositeBinding("2DVector")
            .With("Left", "<Gamepad>/dpad/left")
            .With("Right", "<Gamepad>/dpad/right");
        
        // ジャンプアクションの登録
        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
        jumpAction.AddBinding("<Gamepad>/buttonSouth");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    private void Move()
    {
        transform.position += new Vector3(moveInput.x, 0, 0) * Time.deltaTime * 5f;
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    private void Jump()
    {
        // 地面に設置していて、space/Southボタンが押されたときにジャンプする
        if (isGrounded && jumpPressed)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, 5f);
            isGrounded = false;
            jumpPressed = false;
        }
    }
    /// <summary>
    /// オブジェクトが有効になった時の処理
    /// </summary>
    private void OnEnable()
    {
        // 移動アクションの有効化とイベント登録
        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        // ジャンプアクションの有効化とイベント登録
        jumpAction.Enable();
        jumpAction.performed += OnJumpPerformed;
    }

    /// <summary>
    /// 移動アクションが実行されたときの処理
    /// </summary>
    /// <param name="ctx"></param>
    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }
    /// <summary>
    /// 移動アクションがキャンセルされたときの処理
    /// </summary>
    /// <param name="ctx"></param>
    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    /// <summary>
    /// ジャンプアクションが実行されたときの処理
    /// </summary>
    /// <param name="ctx"></param>
    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            jumpPressed = true;
        }
    }

    /// <summary>
    /// オブジェクトに衝突したときの処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
