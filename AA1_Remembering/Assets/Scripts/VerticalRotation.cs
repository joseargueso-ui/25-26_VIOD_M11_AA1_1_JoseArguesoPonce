using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalRotation : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public float minAngle = -30;
    public float maxAngle = 60;

    float angle;

    void Update()
    {
        angle += -Mouse.current.delta.value.y * rotationSpeed;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }
}
