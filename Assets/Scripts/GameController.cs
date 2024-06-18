using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PinsController pinsController;
    private Ball ball;
    private ScoreManager scoreManager;
    private int rounds = 2;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        pinsController = GameObject.FindObjectOfType<PinsController>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (ball.isBallMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rounds--;
            StartCoroutine(Playing());
        }
    }

    private IEnumerator Playing()
    {
        StartCoroutine(ball.Shoot());
        yield return new WaitForSecondsRealtime(3f);
        int score = pinsController.GetCountOfFallenPins();
        Debug.Log(score);

        ball.ResetPosition();
        pinsController.RemoveFallenPins();

        scoreManager.AddScore(score);

        if(rounds == 0 || score == 10)
            ResetScene();
    }

    private void ResetScene()
    {
        scoreManager.NextPlayer();
        pinsController.ResetPinsPositions();
        rounds = 2;
    }
}
