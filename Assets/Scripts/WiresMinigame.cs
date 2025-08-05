using UnityEngine;
using UnityEngine.UI;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class WiresMinigame : GameBehaiour
{
    public RectTransform Follower;
    public GameObject Point;

    public GameObject currentNode;
    public GameObject currentWire;
    public GameObject currentEnd;
    public bool holdingWire;

    public float amount;
    public float completed;

    public List<GameObject> PotentialNodes = new List<GameObject>();

    public List<GameObject> UseedNodes = new List<GameObject>();

    public GameObject startCon, endCon;

    public AudioSource clikc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (amount > PotentialNodes.Count)
        {
            amount = PotentialNodes.Count;
        }
        if (amount < 1)
        {
            amount = 1;
        }

        for (int i = 0; i < amount; i++)
        {
            int ran = Random.Range(0, PotentialNodes.Count);

            GameObject nod = PotentialNodes[ran];

            nod.SetActive(true);
            PotentialNodes.Remove(nod);
            UseedNodes.Add(nod);

            nod.GetComponent<WireNode>().startt.transform.parent = startCon.transform;
            nod.GetComponent<WireNode>().endd.transform.parent = endCon.transform;

            startCon.transform.GetChild(0).transform.SetSiblingIndex(Random.Range(0, startCon.transform.childCount));
            endCon.transform.GetChild(0).transform.SetSiblingIndex(Random.Range(0, endCon.transform.childCount));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Follower.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Point.transform.position);
    }

    public void wireCompleted()
    {
        completed += 1;

        if (completed >= amount)
        {
            // print("WIRE DONE");
            _GM.GameBeaten();
            StartCoroutine(DieTimer());
            Follower.gameObject.SetActive(false);
        }
        
    }

    public void holdWire(GameObject _wir)
    {
        holdingWire = true;
        currentWire = _wir;
    }
    public void letGoWire()
    {
        holdingWire = false;
        currentWire = null;
    }

    public void getEnd(GameObject _end)
    {
        currentEnd = _end;
    }
    public void loseEnd()
    {
        currentEnd = null;
    }

    public void placeWire()
    {
        if (currentNode != null)
        {
            currentNode.GetComponent<WireWire>().setWire(currentEnd.GetComponent<wireEnd>().val, currentEnd.GetComponent<wireEnd>().endPoint);
            clikc.Play();
        }
    }

    public void Fail()
    {
        //_GM.GameFailed();
        StartCoroutine(DieTimer());
        Follower.gameObject.SetActive(false);
    }

    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return null;
    }

    public void recieveVariables1()
    {
        amount = GetComponent<MinigameSetup>().diffuculty;
        Point = GetComponent<MinigameSetup>().point;
    }
    /*public void recieveVariables2(GameObject _point)
    {
        Point = _point;
    }*/
}
