using NUnit.Framework.Internal;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;

public class CrankMinigame : GameBehaiour
{
    public GameObject Point;

    public GameObject folower;
    public RectTransform rt;

    public bool following;

    public GameObject Pivot;
    public GameObject Model;

    private int dsad;

    public GameObject rotref;

    public float multiplier = 5;

    public float curVal;

    public float valu;
    public float valuThresh;

    public Image bar;

    private bool won = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rt.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Point.transform.position);
        // Vector3 dir = rotref.transform.position - Pivot.transform.position;

        if (following == true)
        {
            Pivot.transform.rotation = Quaternion.FromToRotation(Pivot.transform.right, Pivot.transform.position - Input.mousePosition) * Pivot.transform.rotation;

            //curVal = Vector3.SignedAngle(Model.transform.right, Pivot.transform.right, Vector3.up) * multiplier;
            curVal = Vector3.SignedAngle(rotref.transform.right, Pivot.transform.right, Vector3.forward) * multiplier;

            valu += curVal;
            if (valu <= 0)
            {
                valu = 0;
            }

            if (valu >= valuThresh && won == false)
            {
                gameWin();
            }

            bar.fillAmount = valu / valuThresh;
        }
    }

    void LateUpdate()
    { 
        if (following == true)
        {
            if (dsad >= 2)
            {
                rotref.transform.rotation = Pivot.transform.rotation;
                dsad = 0;
            }

            dsad += 1;

        }
    }
  
    public void startFollow()
    {
        following = true;
        Model.transform.parent = Pivot.transform;
    }
    public void endFollow()
    {
        following = false;
        Model.transform.parent = folower.transform;
    }

    public void gameWin()
    {
        won = true;
        folower.gameObject.SetActive(false);
        _GM.GameBeaten();
        StartCoroutine(DieTimer());
        
    }

    public void Fail()
    {
        //audL.Play();
        _GM.GameFailed();
        StartCoroutine(DieTimer());
        folower.SetActive(false);
    }
    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return null;
    }

    public void recieveVariables1()
    {
        valuThresh = ((GetComponent<MinigameSetup>().diffuculty) * 5) + 5;
        Point = GetComponent<MinigameSetup>().point;
    }
}
