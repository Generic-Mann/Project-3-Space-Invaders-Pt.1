using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public delegate void EnemyDied(int points);
  public static event EnemyDied OnEnemyDied;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

     void OnCollisionEnter2D(Collision2D collision)
    {

      if (collision.gameObject.CompareTag("Octo"))
      {
        OnEnemyDied?.Invoke(10);
      }
      else if (collision.gameObject.CompareTag("Crab"))
      {
        OnEnemyDied?.Invoke(20);
      }
      else if (collision.gameObject.CompareTag("Squid"))
      {
        OnEnemyDied?.Invoke(30);
      }
      else if (collision.gameObject.CompareTag("Ufo"))
      {
        int ufoPoints = Random.Range(1, 7) * 50;
        OnEnemyDied?.Invoke(ufoPoints);
      }

      Destroy(collision.gameObject);
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.linearVelocity = Vector2.up * speed; 
    }
}
