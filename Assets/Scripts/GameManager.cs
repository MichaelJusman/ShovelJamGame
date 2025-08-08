using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager>
{
    public GameObject canvass;

    [Header("Mingames")]
    public GameObject currentMinigame;

    public GameObject[] gameses;
    public int cur;
    public int difTresh = 5;

    [Header("Mingames Variables")]
    public GameObject activeGame;
    public GameObject CurrentPoint;
    public bool inGame;

    public float completed;
    public float Difficulty;

    public float winThresh = 20;

    public GameObject winBar;
    public Slider winBarr;
    [Header("Win/Lose")]
    public GameObject WinScreen;
    public GameObject LoseScreen;

    public GameObject car;

    public GameObject playerCma;
    public GameObject playerCmaRef;

    public GameObject cutsceneEnvironment;


    public GameObject UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMinigame = gameses[0];
        //StartCoroutine(NewGame(ringOBJ, 1));
        winBarr.maxValue = winThresh;
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
            GameObject dsa = Instantiate(currentMinigame, transform.position, transform.rotation, canvass.transform);
            /*dsa.GetComponent<RingMinigame>().Point = CurrentPoint;
            dsa.GetComponent<RingMinigame>().spinSpeed += (Difficulty * 6);*/
            dsa.GetComponent<MinigameSetup>().point = CurrentPoint;
            dsa.GetComponent<MinigameSetup>().diffuculty = Difficulty;
            dsa.GetComponent<MinigameSetup>().updateGame();
            activeGame = dsa;
        } 
    }

    public void GameBeaten()
    {
        completed += 1;
        Difficulty += 1;

        if (Difficulty >= difTresh)
        {
            Difficulty = 0;
            cur += 1;
            if (cur > gameses.Length - 1)
            {
                cur = 0;
                Difficulty = difTresh;
                difTresh += difTresh;
            }
            currentMinigame = gameses[cur];
            _EB.aggrevate();
        }

        StartCoroutine(NewGame(currentMinigame, 1));

        winBar.SetActive(true);
        winBarr.value = completed;
       // winBar.fillAmount = completed / winThresh;

        if (completed >= winThresh)
        {
            PlayerWin();
        }
    }

    public void GameFailed()
    {
        StartCoroutine(NewGame(currentMinigame, 1));
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
        Destroy(activeGame);
        UI.SetActive(false);
        car.SetActive(false);
        cutsceneEnvironment.SetActive(true);

        _EB.active = false;
        _EB.gameObject.SetActive(false);

        playerCma.transform.position = playerCmaRef.transform.position;
        playerCma.transform.rotation = playerCmaRef.transform.rotation;
        playerCma.transform.parent = playerCmaRef.transform;

        WinScreen.SetActive(true);
    }

    public void PlayerLose()
    {
        LoseScreen.SetActive(true);
    }
}
