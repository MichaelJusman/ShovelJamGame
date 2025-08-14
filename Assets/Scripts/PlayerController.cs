using UnityEngine;
using UnityEngine.Events;

public enum Facing
{
    Fowards,
    Back,
    Left,
    Right, 
    Key
}
public class PlayerController : Singleton<PlayerController>
{
    [Header("Movement Variables")]
    public Facing Direction;

    public bool OnKey;
    public Animator anim;

    public GameObject FrontRef, BackRef, LeftRef, RightRef;

    public GameObject Pivot;
    public GameObject CurrentRef;
    public float LerpSPeed;

    [Header("FlashLight")]
    public FlashLightBehav FLB;
    public bool FOn;

    [Header("Events")]
    public UnityEvent getUpEvemt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            OnKey = !OnKey;
            if (OnKey == true)
            {
                GoDown();
                LookAtDirection(FrontRef, Facing.Key);
            } else
            {
                GoUp();
            }
        }*/

        Pivot.transform.rotation = Quaternion.Lerp(Pivot.transform.rotation, CurrentRef.transform.rotation, LerpSPeed * Time.deltaTime);
        Pivot.transform.position = Vector3.Lerp(Pivot.transform.position, CurrentRef.transform.position, LerpSPeed * Time.deltaTime);
        if (OnKey == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                LookAtDirection(FrontRef, Facing.Fowards);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                LookAtDirection(BackRef, Facing.Back);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                LookAtDirection(LeftRef, Facing.Left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                LookAtDirection(RightRef, Facing.Right);
            }
        }

        
    }

    public void GoDown()
    {
        anim.SetBool("Up", false);
        LookAtDirection(FrontRef, Facing.Key);
        OnKey = true;
        _GM.inGame = true;
        _GM.GameFailed();
        flashOff();
    }

    public void GoUp()
    {
        anim.SetBool("Up", true);
        LookAtDirection(FrontRef, Facing.Fowards);
        OnKey = false;
        _GM.inGame = false;
        _GM.FailGame();
        getUpEvemt.Invoke();
    }

    //directional looking
    public void LookAtDirection(GameObject _Ref, Facing dir)
    {
        CurrentRef = _Ref;
        Direction = dir;
    }

    public void LookForwards()
    {
        LookAtDirection(FrontRef, Facing.Fowards);
    }
    public void LookBack()
    {
        LookAtDirection(BackRef, Facing.Back);
    }
    public void LookLeft()
    {
        LookAtDirection(LeftRef, Facing.Left);
    }
    public void LookRight()
    {
        LookAtDirection(RightRef, Facing.Right);
    }

    /*public void toggleFlashlight()
    {
        FOn = !FOn;

        if (FOn == true)
        {
            flashOn();
        }
        else
        {
            flashOff();
        }
    }*/
    public void flashOn()
    {
        if (FLB.Battery > 0)
        {
            //print("on");
            FLB.FLight.SetActive(true);
            FLB.Baudio.Play();
            FOn = true;
        } else
        {
            flashOff();
        }       
    }
    public void flashOff()
    {
        //print("off");
        FLB.FLight.SetActive(false);
        FLB.Baudio2.Play();
        FOn = false;
    }
}
