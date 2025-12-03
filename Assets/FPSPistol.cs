using UnityEngine;

public class FPSPistol : MonoBehaviour
{
    public float damage = 25f;
    public float range = 50f;
    public Camera fpsCamera;  // FPS kamera referansý

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        // Kamera ileri yönünde raycast gönder
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log("Vurulan: " + hit.transform.name);

            HealthSystem targetHealth = hit.transform.GetComponent<HealthSystem>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }
        }
    }
}
