using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

/// <summary>
/// 총알 발사용 스크립트. 
/// </summary>
public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletObject = null;

    private IObjectPool<GameObject> bulletPool = null;
    public IObjectPool<GameObject> BulletPool
    {
        get {
            if(bulletPool == null)
            {
                bulletPool = new ObjectPool<GameObject>(CreateBullet, OnTakeFromPool, OnReturnedToPool);
            }
            return bulletPool;
        }
    }
    
    public void OnFire(InputAction.CallbackContext context)
    {
        BulletPool.Get();
    }

    private GameObject CreateBullet()
    {
        GameObject newBullet = ResetBullet(Instantiate(bulletObject));
        return newBullet;
    }

    private void OnTakeFromPool(GameObject bullet)
    {
        ResetBullet(bullet);
    }

    private void OnReturnedToPool(GameObject bullet) 
    {
        bullet.SetActive(false);
    }

    private GameObject ResetBullet(GameObject bullet)
    {
        BulletMove bulletMove = bullet.GetComponent<BulletMove>();
        // newBullet의 BulletMove에 bulletPool을 세팅해준다.
        bulletMove.SetBulletPool(bulletPool);
        // 위치 초기화
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        return bullet;
    }
}
