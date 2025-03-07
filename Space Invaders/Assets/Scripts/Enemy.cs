using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  //public GameObject enemyBulletPrefab;


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
    Destroy(collision.gameObject);
    }
}
