using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalRotation : MonoBehaviour
{
    public float rotationSpeed = 1;
    void Update()
    {
        transform.localEulerAngles +=
            new Vector3(0, Mouse.current.delta.value.x, 0)
            * rotationSpeed;
    }
}
