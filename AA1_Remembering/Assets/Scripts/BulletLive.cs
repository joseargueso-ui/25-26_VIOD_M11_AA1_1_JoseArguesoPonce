using UnityEngine;

public class BulletLive : MonoBehaviour
{
    public float lifeTime = 5;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
