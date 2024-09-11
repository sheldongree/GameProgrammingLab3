using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 1f;
    public float maxChargeTime = 3f;
    private float chargeTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f;
        }

        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
        }

        if (Input.GetButtonUp("Fire1"))
        {

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            if (bulletComp != null)
            {
                bulletComp.bulletSpeed *= chargeTime;
            }
            chargeTime = 0f;
        }
    }
}
