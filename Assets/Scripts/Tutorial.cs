using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Tutorial : Singleton<Tutorial>
{
    public float dfffzsdg;

    public GameObject[] TextBoxes;

    public GameObject current;
    public int ID;
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

        if (dfffzsdg == 0)
        {
            for (int i = 0; i < TextBoxes.Length; i++)
            {
                if (i > 1)
                {
                    TextBoxes[i].SetActive(false);
                }
            }
        }
        else
        {
            print("donzo");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Advance()
    {
        current.SetActive(false);
        ID += 1;
        TextBoxes[ID].SetActive(true);
        current = TextBoxes[ID];

        if (ID >= 5)
        {
            endTutorial();
            StartCoroutine(Leave());
        }
    }

    public void endTutorial()
    {
        PlayerPrefs.SetFloat("hasCompletedTutorial", 1);
    }

    IEnumerator Leave()
    {
        //SummonMinigame();
        yield return new WaitForSeconds(5);
        for (int i = 0; i < TextBoxes.Length; i++)
        {
            Destroy(TextBoxes[i]);
        }
    }
}
