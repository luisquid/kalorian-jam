//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TextMeshPro TXT_Score;

    void Awake()
    {
        TXT_Score = GetComponent<TextMeshPro>();
        TXT_Score.text = "+" +GameManager.instance.playerStats.counterMultiplier.ToString();
    }

    public void DestroyScoreText()
    {
        Destroy(gameObject);
    }
}
