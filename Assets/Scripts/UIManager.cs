using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject scorePanel;
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text scoreText2;
    public Text best;
    public GameManager gameManager;
    void Start()
    {
        
    }
    public void setScore(int s)
    {
        scoreText.text = s.ToString();
       
    }
    public void GameOver(int s,List<int> lista)
    {
        scorePanel.SetActive(false);
        scoreText2.text = s.ToString();
        int max = lista[0];
        foreach(int score in lista)
        {
            if (score > max) max = score; 
        }
        best.text = max.ToString();
        gameOverPanel.SetActive(true);
       
        
    }
    public void Restart(int s)
    {
        gameOverPanel.SetActive(false);
        setScore(s);
        scorePanel.SetActive(true);
    }
   
  
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
