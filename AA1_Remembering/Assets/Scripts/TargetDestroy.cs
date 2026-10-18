using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    public GameObject brokenPrefab;
    public GameObject model;
    public float respawnTime = 3;
    public int points = 100;

    Collider targetCollider;
    float timer;
    bool destroyed;

    void Start()
    {
        targetCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (!destroyed) {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= respawnTime)
        {
            model.SetActive(true);
            targetCollider.enabled = true;
            destroyed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (destroyed)
        {
            return;
        }
            if (!other.CompareTag("Bullet"))
            {
                return;
            }

        GameObject broken = Instantiate(
            brokenPrefab,
            transform.position,
            transform.rotation);
        Destroy(broken, respawnTime);

        ScoreManager.instance.AddScore(points);
        Destroy(other.gameObject);

        model.SetActive(false);
        targetCollider.enabled = false;
        timer = 0;
        destroyed = true;
    }
}
