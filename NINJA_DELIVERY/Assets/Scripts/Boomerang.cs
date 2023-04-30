using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float _speed = 20f;
    public GameObject _Bullet_one;
    public Rigidbody2D rb;
    public float timeLeft = 0f;
    public float timeEnd = 0.5f;
    void Start()
    {
        rb.velocity = transform.right * _speed;
    }

    private void Update()
    {
        timeLeft = timeLeft + Time.deltaTime;
        if (timeLeft >= timeEnd)
        {
            rb.velocity = (transform.right * -1) * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(_Bullet_one, 0);
        }
        if (collision.tag == "Enemy")
        {
            Debug.Log("Дальше сами пишите");
        }
    }
}
