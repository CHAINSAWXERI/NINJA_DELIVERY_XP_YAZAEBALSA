using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Collider2D myCollider;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject EndPointTP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.transform.position = EndPointTP.transform.position;
        }
    }
}
