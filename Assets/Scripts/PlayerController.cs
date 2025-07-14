using UnityEngine;

public enum Facing
{
    Fowards,
    Back,
    Left,
    Right, 
    Key
}
public class PlayerController : MonoBehaviour
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

        /*if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            LookAtDirection(FrontRef, Facing.Fowards);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            LookAtDirection(BackRef, Facing.Back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LookAtDirection(LeftRef, Facing.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LookAtDirection(RightRef, Facing.Right);
        }*/
    }

    public void GoDown()
    {
        anim.SetBool("Up", false);
        LookAtDirection(FrontRef, Facing.Key);
        OnKey = true;
    }

    public void GoUp()
    {
        anim.SetBool("Up", true);
        OnKey = false;
    }

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
}
