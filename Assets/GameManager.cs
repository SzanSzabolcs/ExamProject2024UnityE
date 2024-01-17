using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int lives = 3; // Kezdeti életek száma

    [SerializeField] Image Live03;
    [SerializeField] Image Live02;
    [SerializeField] Image Live01;

    void Start()
    {
        UpdateLivesUI();
        UpdateScoreUI();
    }

    void GameOver()
    {
        Debug.Log("Game over");
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreUI();

    }
    // Életek csökkentése
    void DecreaseLives()
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
    void UpdateLivesUI()
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

