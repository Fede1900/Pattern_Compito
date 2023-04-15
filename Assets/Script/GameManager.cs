using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public StateMachine<GameStateType> StateMachine { get; } = new();

    public PlayerController player;
    [SerializeField] private List<Enemy> enemies;

    bool win = false;
    bool lose = false;

    private int _punteggio;

    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] TextMeshProUGUI keytext;

    public int Punteggio
    {
        get => _punteggio;
        set
        {
            _punteggio = value;

            OnScoreChanged.Invoke(_punteggio);
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        StateMachine.RegisterState(GameStateType.PlayerTurn, new PlayerTurnState(player));


    }

    private void Start()
    {
        StateMachine.RegisterState(GameStateType.EnemyTurn, new EnemyTurnState(enemies));
        StateMachine.SetState(GameStateType.PlayerTurn);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Update();

        if (lose)
        {
            OnLose();
        }

        if (win)
        {
            OnWin();
        }
    }

    public delegate void OnScoreChangedFunction(int value);
    public event OnScoreChangedFunction OnScoreChanged;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void SetLose()
    {
        lose = true;
        Time.timeScale = 0;
        loseText.gameObject.SetActive(true);
        keytext.gameObject.SetActive(true);
    }

    public void SetWin()
    {
        win = true;
        Time.timeScale = 0;
        winText.gameObject.SetActive(true);
        keytext.gameObject.SetActive(true);
    }

    public void OnLose()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void OnWin()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   //al momento riavvio la scena
        }
    }


}
