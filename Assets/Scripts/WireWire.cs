using UnityEngine;

public class WireWire : MonoBehaviour
{
    public WiresMinigame WM;

    public bool lockedIn;

    public int startValue;
    //public int endValue;

    //positions
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform endStartPoint;
    public GameObject Middle;

    public RectTransform lengthrt;

    public wireEnd we;

    public GameObject button1, button2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //endStartPoint = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        //wire length behav
        lengthrt.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, 0.5f);
        lengthrt.sizeDelta = new Vector2(Vector3.Distance(startPoint.transform.position, endPoint.transform.position) / 1.2f, 10);
        lengthrt.transform.rotation = Quaternion.FromToRotation(lengthrt.transform.right, startPoint.transform.position - endPoint.transform.position) * lengthrt.transform.rotation;
    }

    public void pickUp()
    {
        if (lockedIn == false)
        {
            endPoint.transform.position = Input.mousePosition;
        }

        WM.currentNode = gameObject;
    }
    public void returnWire()
    {
        if (lockedIn == false)
        {
            endPoint.transform.position = endStartPoint.position;
            WM.currentNode = null;
        }
      
    }

    public void setWire(int _val, GameObject _point)
    {
        WM.currentWire.GetComponent<RectTransform>().position = _point.transform.position;

        if (_val == startValue)
        {
            lockedIn = true;
            WM.wireCompleted();
            WM.currentNode = null;
            button1.SetActive(false);
            button2.SetActive(false);
        }
    }
}
