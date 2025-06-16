using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 총알을 움직이는 스크립트.
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;    
    private IObjectPool<GameObject> bulletPool;

    private void OnEnable()
    {
        Invoke("Despawn", 2f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    private void Despawn()
    {
        bulletPool.Release(gameObject);
    }

    public void SetBulletPool(IObjectPool<GameObject> bulletPool)
    {
        this.bulletPool = bulletPool;
    }
}
