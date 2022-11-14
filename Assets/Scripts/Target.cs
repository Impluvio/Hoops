using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    ScoreBoard scoreBoard; //refs the scoreboard class scoreboard variable of class scoreboard.
    [SerializeField] int pointsValue = 20;
    AudioSource source;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");
        scoreBoard.IncreaseScore(pointsValue);
        source.Play();
    }

}

