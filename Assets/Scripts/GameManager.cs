using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public GameObject canvass;

    [Header("Mingames")]
    public GameObject ringOBJ;

    [Header("Mingames Variables")]
    public GameObject activeGame;
    public GameObject CurrentPoint;
    public bool inGame;

    public float completed;
    public float Difficulty;

    public float winThresh = 20;

    [Header("Win/Lose")]
    public GameObject WinScreen;
    public GameObject LoseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(NewGame(ringOBJ, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame == true)
        {

        }
    }

    public void SummonMinigame()
    {
        if (inGame == true)
        {
            GameObject dsa = Instantiate(ringOBJ, transform.position, transform.rotation, canvass.transform);
            dsa.GetComponent<RingMinigame>().Point = CurrentPoint;
            dsa.GetComponent<RingMinigame>().spinSpeed += (Difficulty * 3);
            activeGame = dsa;
        } 
    }

    public void GameBeaten()
    {
        completed += 1;
        Difficulty += 1;
        StartCoroutine(NewGame(ringOBJ, 1));

        if (completed >= winThresh)
        {
            PlayerWin();
        }
    }

    public void GameFailed()
    {
        StartCoroutine(NewGame(ringOBJ, 1));
    }

    IEnumerator NewGame(GameObject _game, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SummonMinigame();
        yield return null;
    }

    public void FailGame()
    {
        activeGame.GetComponent<GameFailer>().FailGame();
    }

    public void PlayerWin()
    {

    }

    public void PlayerLose()
    {
        LoseScreen.SetActive(true);
    }
}
