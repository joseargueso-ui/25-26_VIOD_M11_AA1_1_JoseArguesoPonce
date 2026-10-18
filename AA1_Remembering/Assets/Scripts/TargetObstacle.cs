using UnityEngine;

public class TargetObstacle : MonoBehaviour
{
    public int points = -100;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;

        ScoreManager.instance.AddScore(points);
        Destroy(other.gameObject);
    }
}
