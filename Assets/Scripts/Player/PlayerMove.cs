using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어 이동을 위한 클래스. 지금은 편집할 필요가 없습니다.
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Animator animator;

    private Vector2 moveAmount = Vector2.zero;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate((Vector3)moveAmount * Time.deltaTime * moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
        animator.SetFloat("xAmount", moveAmount.x);        
    }
    
}
