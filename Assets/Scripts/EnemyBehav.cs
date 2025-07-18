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

    [Header("Jumpscare")]
    public GameObject JumpscareCamRef;
    public GameObject Jumpscare;
    public GameObject PlayerCam;
    public Animator JumpScarer;
    public Animator car;

    public GameObject Menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showUpTimer2 = showUpTimer;
        killTimer2 = killTimer;

        Jumpscare.SetActive(false);
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

        //ModelAnim.Play("GoUpSide");

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

        if (ran != 0)
        {
            ModelAnim.Play("GoUpSide");
        } else
        {
            ModelAnim.Play("GoUpFront");
        }
    }
    public void kill()
    {
        active = false;
        //print("youDied");
        Model.SetActive(false);
        Menu.SetActive(false);
        StartCoroutine(PlayScare());
        //Jumpscare.SetActive(true);

        car.Play("GuyInCar");

        /*PlayerCam.transform.parent = JumpscareCamRef.transform;
        PlayerCam.transform.position = JumpscareCamRef.transform.position;
        PlayerCam.transform.rotation = JumpscareCamRef.transform.rotation;
        Destroy(_GM.activeGame);*/
    }
    IEnumerator PlayScare()
    {

        yield return new WaitForSeconds(1);
        Jumpscare.SetActive(true);
        PlayerCam.transform.parent = JumpscareCamRef.transform;
        PlayerCam.transform.position = JumpscareCamRef.transform.position;
        PlayerCam.transform.rotation = JumpscareCamRef.transform.rotation;
        Destroy(_GM.activeGame);
        _GM.inGame = false;
    }


    public void GoAway()
    {
        Leaving = true;
        ModelAnim.SetBool("DuckDown", true);
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
        yield return new WaitForSeconds(2);
        ModelAnim.SetBool("DuckDown", false);
        Model.SetActive(false);
        Leaving = false;
    }
}
