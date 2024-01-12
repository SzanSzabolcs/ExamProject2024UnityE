using UnityEngine.UI;
using UnityEngine;

class ScorePoints : MonoBehaviour
{
    public Text scoreText;

    int score= 0;

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

}
