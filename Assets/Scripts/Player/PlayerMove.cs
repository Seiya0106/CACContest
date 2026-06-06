using Unity.VisualScripting;
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
        
        // ジャンプアクションの登録
        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
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
        Fall();
    }

    /// <summary>
    /// オブジェクトに衝突したときの処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnTheGround(collision);
    }

    /// <summary>
    /// オブジェクトから離れたときの処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
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
    /// プレイヤーの落下処理
    /// </summary>
    private void Fall()
    {
        // ジャンプの最高点に達したとき
        if (playerRigidbody.linearVelocity.y < 0)
        {
            playerRigidbody.linearVelocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
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
    /// オブジェクトが地面に接地しているかの判定処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTheGround(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ContactPoint2D contactPoint = collision.contacts[0];    // 衝突点の法線ベクトルを取得
            if (contactPoint.normal.y > 0.5f)   // 地面に接地しているか
            {
                isGrounded = true;
            }
        }
    }
}
