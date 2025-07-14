using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyBehav : Singleton<EnemyBehav>
{
    public bool active;

    public bool peering;

    public bool sitting;
    public bool Leaving;

    [Header("Behaviour")]
    public float showUpTimer;
    private float showUpTimer2;

    public float killTimer;
    private float killTimer2;

    [Header("Aesthetics")]
    public GameObject Model;
    public Animator ModelAnim;

    [Header("PositionPoints")]
    public GameObject Front;
    public GameObject Back;
    public GameObject Left;
    public GameObject Right;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showUpTimer2 = showUpTimer;
        killTimer2 = killTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (peering == false)
            {
                showUpTimer -= 1 *Time.deltaTime;

                if (showUpTimer < 0)
                {                    
                    ShowUp();
                }
            } else
            {
                killTimer -= 1 *Time.deltaTime;

                if (killTimer < 0 && Leaving == false)
                {
                    kill();
                }
            }
        }
    }

    public void ShowUp()
    {
        peering = true;
        Model.SetActive(true);
        int ran = Random.Range(0, 3);
        switch (ran)
        {
            case 0:
                Model.transform.position = Front.transform.position;
                Model.transform.rotation = Front.transform.rotation;
                break;
            case 1:
                Model.transform.position = Back.transform.position;
                Model.transform.rotation = Back.transform.rotation;
                break;
            case 2:
                Model.transform.position = Left.transform.position;
                Model.transform.rotation = Left.transform.rotation;
                break;
            case 3:
                Model.transform.position = Right.transform.position;
                Model.transform.rotation = Right.transform.rotation;
                break;
        }
    }
    public void kill()
    {
        print("youDied");
    }

    public void GoAway()
    {
        Leaving = true;
        StartCoroutine(Leave());
    }

    IEnumerator Leave()
    {
        
        //SummonMinigame();
        yield return new WaitForSeconds(2);
        peering = false;
        Leaving = true;
        showUpTimer = (showUpTimer2 + Random.Range(-1, 3));
        yield return new WaitForSeconds(1);
        Model.SetActive(false);
    }
}
