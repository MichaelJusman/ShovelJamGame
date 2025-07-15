using UnityEngine;
using UnityEngine.UI;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEditor.PlayerSettings;

public class RingMinigame : GameBehaiour
{
    public float spinSpeed;
    public GameObject Spinner;
    public GameObject reff;
    public RectTransform rt;

    public GameObject Follower;
    public GameObject Point;

    [Header("Varaibles")]
    public float SpinnerRot;
    public float Min, Max;
    public float offset;

    [Header("Art")]
    public Image Ring;
    public Image Pointer;

    [Header("Pressable")]
    public bool Pressable;

    public GameObject win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float ran = Random.Range(10, 180);

        Min = 360 - ran;

        Ring.fillAmount = (ran / 360);


        offset = Random.Range(0, 360);

        Ring.transform.Rotate(0,0,offset);
        /*Max += offset;
        if (Max > 360)
        {
            Max -= 360;
        }

        Min = 360 - ran + offset;
        if (Min > 360)
        {
            Min -= 360;
        }*/
        Spinner.transform.rotation = Quaternion.FromToRotation(-Spinner.transform.up, Spinner.transform.position - reff.transform.position) * Spinner.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rt.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Point.transform.position);

        SpinnerRot = Spinner.transform.localEulerAngles.z;

        if (SpinnerRot > Min && SpinnerRot < Max)
        {
            Pointer.color = Color.green;
            Pressable = true;
        } else
        {
            Pointer.color = Color.white;
            Pressable = false;
        }

        Spinner.transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (Pressable == true)
            {
                Succeed();
            } else
            {
                Fail();
            }
        }*/
    }

    public void check()
    {
        if (Pressable == true)
        {
            Succeed();
        }
        else
        {
            Fail();
        }
    }

    public void Succeed()
    {
        //Instantiate(win, transform.position, transform.rotation, transform.parent);
        _GM.GameBeaten();
        StartCoroutine(DieTimer());
        Follower.SetActive(false);
    }
    public void Fail()
    {
        _GM.GameFailed();
        StartCoroutine(DieTimer());
        Follower.SetActive(false);
    }

    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return null;
    }
}
