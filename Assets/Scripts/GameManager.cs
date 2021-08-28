using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int score=0;
    List<int> scores;
    public PlayerController playerController;
    public RoadManager roadManager;
    public UIManager uIManager;
    public static GameState gameState;
    public AudioScript audioScript;



    public enum GameState
    {
        start,
        running,
        gameover,
        restart
         
    }
    void Start()
    {
        
    }
    void Awake()
    {
        scores = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButton(0))) && gameState==GameState.start)
        {
            StartGame();
            
        }
     //Debug.Log(gameState);
    }
    public void StartGame()

    {
        playerController.AnimationStop();
        playerController.AnimationWingStart();
            gameState = GameState.running;
          


    }
    public void GameOver()
    {
        gameState = GameState.gameover;
        playerController.AnimationWingStop();
       playerController.audioGameOver.Play();
        scores.Add(score);
        uIManager.GameOver(score,scores);



    }
    public void Restart()
    {
      
        score = 0;
        roadManager.Reset();
        uIManager.Restart(score);
        playerController.AnimationStart();
        gameState = GameState.start;
        playerController.Reset();


    }
    
    public void DetectPipe()
    {
        score++;
        audioScript.Play();
        //Debug.Log(score);
        uIManager.setScore(score);

    }
}
   

