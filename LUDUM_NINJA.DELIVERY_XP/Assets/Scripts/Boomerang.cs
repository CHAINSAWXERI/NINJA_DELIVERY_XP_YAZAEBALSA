using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float _speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * _speed;

    }
}
