using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  public GameObject bulletPreFab;

  public Transform shottingOffset;

  Animator playerAnimator;

  private int score = 0;
  private int hiscore = 0;
  public float speed = 5f;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI hiscoreText;


  void Start()
  {
    Bullet.OnEnemyDied += EnemyOnOnEnemyDied;
    playerAnimator = GetComponent<Animator>();
    hiscore = PlayerPrefs.GetInt("HighScore", 0);
    score = 0;
    hiscoreText.text = $"HI-SCORE\n{hiscore:D4}";
  }

  void OnDestroy()
  {
    Bullet.OnEnemyDied -= EnemyOnOnEnemyDied;
  }

  void EnemyOnOnEnemyDied(int points)
  {

    Debug.Log($"Enemy killed, you scored: {points}");

    score += points;

    if (score > hiscore)
    {
        hiscore = score;

        PlayerPrefs.SetInt("HighScore", hiscore);
        PlayerPrefs.Save();

        Debug.Log($"New High Score: {hiscore}!");
    }
    scoreCounts();
  }

    void scoreCounts()
    {
      scoreText.text = $"SCORE\n{score:D4}";
      hiscoreText.text = $"HI-SCORE\n{hiscore:D4}";
    }

  
    // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      playerAnimator.SetTrigger("Shoot");

      GameObject shot = Instantiate(bulletPreFab, shottingOffset.position, Quaternion.identity);

      Destroy(shot, 3f);

    }

    float moveDirection = 0f;

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      moveDirection = -1f;
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      moveDirection = 1f;
    }
    transform.position += new Vector3(moveDirection * speed * Time.deltaTime, 0, 0);
  }
}

