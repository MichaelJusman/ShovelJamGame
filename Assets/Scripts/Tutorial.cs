using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
//using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Tutorial : Singleton<Tutorial>
{
    //public float dfffzsdg;

    public GameObject[] TextBoxes;

    public GameObject current;
    public int ID;

    public bool done;

    public GameObject fakeBUtton;
    public GameObject lookUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*float check = PlayerPrefs.GetFloat("hasCompletedTutorial");

        if (check == 0)
        {
            for (int i = 0; i < TextBoxes.Length; i++)
            {
                if (i > 1)
                {
                    TextBoxes[i].SetActive(false);
                }
            }
        } else
        {
            print("donzo");
        }
        for (int i = 0; i < TextBoxes.Length; i++)
        {
            if (i > 1)
            {
                TextBoxes[i].SetActive(false);
            }
        }*/

        float check = PlayerPrefs.GetFloat("hasCompletedTutorial");

        if (check == 0)
        {
            lookUp.SetActive(false);
            for (int i = 0; i < TextBoxes.Length; i++)
            {
                if (i > 1)
                {
                    TextBoxes[i].SetActive(false);
                }
            }
            TextBoxes[0].SetActive(true);
        }
        else
        {
            print("donzo");
            endTutorial();
            StartCoroutine(Leave());
            _PC.GoDown();
            _PC.anim.Play("LookKey");
            fakeBUtton.SetActive(false);
            done = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //test
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetFloat("hasCompletedTutorial", 0);
        }*/
    }

    public void Advance()
    {
        if (done == false)
        {
            current.SetActive(false);
            ID += 1;
            TextBoxes[ID].SetActive(true);
            current = TextBoxes[ID];

            if (ID >= 4 && done == false)
            {
                endTutorial();
                StartCoroutine(Leave());
                done = true;
            }

            if (ID == 2)
            {
                lookUp.SetActive(true);
                _EB.active = true;
                _EB.ShowUp();
                _EB.killTimer = 99;
            }
        }
    }

    public void endTutorial()
    {
        PlayerPrefs.SetFloat("hasCompletedTutorial", 1);      
    }

    IEnumerator Leave()
    {
        _EB.active = true;
        _PC.FLB.drain = true;
        //SummonMinigame();
        yield return new WaitForSeconds(5);
        for (int i = 0; i < TextBoxes.Length; i++)
        {
            Destroy(TextBoxes[i]);
        }
    }
}
