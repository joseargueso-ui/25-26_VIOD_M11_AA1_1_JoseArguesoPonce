using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    public Transform cam;

    public float horizontalSensitivity = 100;
    public float verticalSensitivity = 100;
    public float maxDistance = 8;
    public float margin = 0.2f;

    public float minAngle = -20;
    public float maxAngle = 80;

    float yaw;
    float pitch;

    void Update()
    {
        // 1. Leer teclas WASD
        Vector2 input = Vector2.zero;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.wKey.isPressed) input.y += 1;

        // 2. Acumular ángulos
        yaw += input.x * horizontalSensitivity * Time.deltaTime;
        pitch += input.y * verticalSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minAngle, maxAngle);

        // 3. Rotar el pivote
        transform.localEulerAngles = new Vector3(pitch, yaw, 0);

        // 4. Colocar la cámara
        PlaceCamera();
    }

    void PlaceCamera()
    {
        Vector3 direction = -transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
        {
            cam.position = hit.point - direction * margin;
        }
        else
        {
            cam.position = transform.position + direction * maxDistance;
        }

        cam.LookAt(transform.position);
    }
}
