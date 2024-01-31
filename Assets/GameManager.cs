using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour

{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int lives = 3; // Kezdeti életek száma

    [SerializeField] Image Live03;
    [SerializeField] Image Live02;
    [SerializeField] Image Live01;
    [SerializeField] GameObject gameOverObject;
    [SerializeField] GameObject Demon;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Credits;


    void Start()
    {
        UpdateLivesUI();
        UpdateScoreUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void MainmenuGame()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }

    public void CreditsGame()
    {
        Demon.SetActive(false);
        Canvas.SetActive(false);
        Credits.SetActive(true);
    }

    public void CreditsOffGame()
    {
        Demon.SetActive(true);
        Canvas.SetActive(true);
        Credits.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        //GAME OVER SCREEN ON
        gameOverObject.SetActive(true);
    }

    public void GameQuit()
    {
        // Játék leállítása
        Application.Quit();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreUI();

        // Ellenõrizzük, hogy elértük-e a 100 pontot
        if (score == 100)
        {
            // Hozzáadjuk a plusz életet
            IncreaseLives();
        }
    }

    void IncreaseLives()
    {
        // Ellenõrizzük, hogy az életek ne legyenek több mint 3
        if (lives < 3)
        {
            lives++;
            UpdateLivesUI();
        }
    }

    // Életek csökkentése
    public void DecreaseLives()
    {
        lives--;

        // Frissítjük az életképeket a Canvas-en
        UpdateLivesUI();

        if (lives <= 0)
        {
            // Ha elfogytak az életek, játék vége
            GameOver();
        }
    }

    // UI frissítése a jelenlegi életekkel
    public void UpdateLivesUI()
    {
        // Ellenõrizzük, hogy a képek ne null legyenek, és ha nem, akkor frissítjük azokat
        if (Live03 != null && Live02 != null && Live01 != null)
        {
            // Frissítjük az életképeket a Canvas-en
            switch (lives)
            {
                case 3:
                    Live03.color = Color.white;
                    Live02.color = Color.white;
                    Live01.color = Color.white;
                    break;
                case 2:
                    Live03.color = Color.black;
                    Live02.color = Color.white;
                    Live01.color = Color.white;
                    break;
                case 1:
                    Live03.color = Color.black;
                    Live02.color = Color.black;
                    Live01.color = Color.white;
                    break;
                default:
                    Live03.color = Color.black;
                    Live02.color = Color.black;
                    Live01.color = Color.black;
                    break;
            }
        }
        else
        {
            Debug.LogError("One or more live images are null! Make sure they are assigned in the Inspector.");
        }
    }

    void UpdateScoreUI()
    {
        // Ellenõrizzük, hogy a scoreText ne null legyen, és ha nem, akkor frissítjük a szöveget
        if (scoreText != null)
        {
            // A szöveget frissítjük a jelenlegi pontszámmal
            scoreText.text = "SCORE: " + score.ToString("D3");
        }
    }
}

