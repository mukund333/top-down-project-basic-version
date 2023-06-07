using UnityEngine;

public class BulletFireSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    public float bulletSpeed = 10f;

    private float nextFireTime = 0f;

    public Transform Aim;
    public float offsetAngle;

    private void Awake()
    {
        //Aim = GetComponentInParent<Transform>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    //private void FireBullet()
    //{
    //    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Aim.transform.rotation);
    //    Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

    //    if (bulletRigidbody != null)
    //    {
    //        bulletRigidbody.velocity = bullet.transform.up * bulletSpeed;
    //    }
    //}

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        if (bulletRigidbody != null)
        {
            Vector3 aimRotationEuler = Aim.rotation.eulerAngles;
            Quaternion offsetRotation = Quaternion.Euler(0f, 0f, aimRotationEuler.z + offsetAngle);

            bullet.transform.rotation = offsetRotation;

            bulletRigidbody.velocity = bullet.transform.up * bulletSpeed;
        }
    }

}
