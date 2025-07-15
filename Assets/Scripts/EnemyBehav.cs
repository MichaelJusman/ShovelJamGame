using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyBehav : Singleton<EnemyBehav>
{
    public Facing Location;

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

    [Header("PositionPoints")]
    public GameObject JumpscareCamRef;
    public Animator JumpScarer;

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


                if (_PC.Direction == Location && _PC.FOn == true && Leaving == false)
                {
                    print("leaving");
                    GoAway();
                }
            }
        }
    }

    public void ShowUp()
    {
        peering = true;
        Model.SetActive(true);
        int ran = Random.Range(0, 4);
        switch (ran)
        {
            case 0:
                Model.transform.position = Front.transform.position;
                Model.transform.rotation = Front.transform.rotation;
                Location = Facing.Fowards;
                break;
            case 1:
                Model.transform.position = Back.transform.position;
                Model.transform.rotation = Back.transform.rotation;
                Location = Facing.Back;
                break;
            case 2:
                Model.transform.position = Left.transform.position;
                Model.transform.rotation = Left.transform.rotation;
                Location = Facing.Left;
                break;
            case 3:
                Model.transform.position = Right.transform.position;
                Model.transform.rotation = Right.transform.rotation;
                Location = Facing.Right;
                break;
            case 4:
                print("fsdfsdfsdfsdfsdfsdfsdfwg");
                break;
        }
    }
    public void kill()
    {
        print("youDied");
        Model.SetActive(false);
    }

    public void GoAway()
    {
        Leaving = true;
        StartCoroutine(Leave());

        if (_TT.ID == 3)
        {
            _TT.Advance();
        }
    }

    IEnumerator Leave()
    {      
        //SummonMinigame();
        yield return new WaitForSeconds(1);
        peering = false;
        
        showUpTimer = (showUpTimer2 + Random.Range(-2, 5));
        killTimer = (killTimer2 + Random.Range(-1, 3));
        yield return new WaitForSeconds(1);
        Model.SetActive(false);
        Leaving = false;
    }
}
