using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int lives = 3; // Kezdeti �letek sz�ma

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
    // �letek cs�kkent�se
    void DecreaseLives()
    {
        lives--;

        // Friss�tj�k az �letk�peket a Canvas-en
        UpdateLivesUI();

        if (lives <= 0)
        {
            // Ha elfogytak az �letek, j�t�k v�ge
            GameOver();
        }
    }

    // UI friss�t�se a jelenlegi �letekkel
    void UpdateLivesUI()
    {
        // Ellen�rizz�k, hogy a k�pek ne null legyenek, �s ha nem, akkor friss�tj�k azokat
        if (Live03 != null && Live02 != null && Live01 != null)
        {
            // Friss�tj�k az �letk�peket a Canvas-en
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
        // Ellen�rizz�k, hogy a scoreText ne null legyen, �s ha nem, akkor friss�tj�k a sz�veget
        if (scoreText != null)
        {
            // A sz�veget friss�tj�k a jelenlegi pontsz�mmal
            scoreText.text = "SCORE: " + score.ToString("D3");
        }

    }
}

