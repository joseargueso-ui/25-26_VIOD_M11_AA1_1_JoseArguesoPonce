using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootForce = 20;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
