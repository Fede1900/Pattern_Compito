using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnScoreChanged += SetScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetScore(int Score)
    {
        ScoreText.text = "Punteggio: " + Score.ToString();
    }
}
