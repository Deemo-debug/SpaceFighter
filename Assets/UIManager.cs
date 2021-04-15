using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Image first, second, third;
    int life = 3;
    int score;

    public void GetScore(int amount)
    {
        string zero = "000000";
        score += amount;
        scoreText.text = "SCORE: " + zero.Substring(0, zero.Length - score.ToString().Length) + score;
    }

    public void TakeDamage()
    {
        life--;
        if (life == 3)
        {
            first.enabled = true;
            second.enabled = true;
            third.enabled = true;
        }
        else if (life == 2)
        {
            first.enabled = true;
            second.enabled = true;
            third.enabled = false;
        }
        else if(life == 1)
        {
            first.enabled = true;
            second.enabled = false;
            third.enabled = false;
        }
        else //life == 0
        {
            first.enabled = false;
            second.enabled = false;
            third.enabled = false;

            //GameOver
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
