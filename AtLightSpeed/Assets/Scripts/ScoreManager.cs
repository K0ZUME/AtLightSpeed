using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public float score;
    public float highScore;
    private Player player;
    private CameraMovement cameraMovement;
    private SpawnObstacles spawnObstacles;
    private LoopingBackground loopingBackground;

    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        cameraMovement = GameObject.FindObjectOfType<CameraMovement>();
        spawnObstacles = GameObject.FindObjectOfType<SpawnObstacles>();
        loopingBackground = GameObject.FindObjectOfType<LoopingBackground>();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", 0);
            Load();
        }

        else
        {
            Load();
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            player.UpdateScore(score);
            cameraMovement.UpdateScore(score);
            spawnObstacles.UpdateScore(score);
            loopingBackground.UpdateScore(score);
        }

        if (highScore < score)
        {
            highScore = score;
            highScoreText.text = "High Score: "+ ((int)highScore).ToString();
            Save();
        }
    }

    private void Load()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        highScoreText.text = "High Score: " + ((int)highScore).ToString();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
