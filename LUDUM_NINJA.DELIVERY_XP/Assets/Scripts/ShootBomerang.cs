using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBomerang : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _bulletp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        GameObject _Bullet_one = Instantiate(_bulletp, _firePoint.position, _firePoint.rotation);
        Destroy(_Bullet_one, 1);
    }
}
