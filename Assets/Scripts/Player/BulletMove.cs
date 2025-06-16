using UnityEngine;

/// <summary>
/// 총알을 움직이는 스크립트.
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;  

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    // TODO: 총알이 화면 밖으로 나가면 Pool에 돌아가게끔 만들어보자
}
