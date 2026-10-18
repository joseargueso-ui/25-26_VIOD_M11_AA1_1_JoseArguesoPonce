using UnityEngine;

public class PathMover : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2;

    int currentIndex;

    void Update()
    {
        Vector3 target = points[currentIndex].position;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentIndex = (currentIndex + 1) % points.Length;
        }
    }
}
