using NUnit.Framework.Internal;
//using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class FlashLightBehav : GameBehaiour
{
    public bool drain;

    public GameObject FLight;
    public float lightDist;
    public float Dampning;

    public float Battery;
    private float Battery2;

    public Image BatteryUI;
    public GameObject BatteryUIHolder;
    public float shakeSpeed;
    public float shakeSize;
    private Vector3 BPos;

    public AudioSource Baudio;
    public AudioSource Baudio2;

    public Color BatCol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BPos = BatteryUIHolder.transform.position;
        if (PlayerPrefs.GetInt("batt") == 1)
        {
            Battery = Battery / 3;
        }

        Battery2 = Battery;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lightDist));

        BPos = Input.mousePosition;

        FLight.transform.rotation = Quaternion.FromToRotation(FLight.transform.forward, FLight.transform.position - pos) * FLight.transform.rotation;

        if (_PC.FOn == true && drain == true)
        {
            Battery -= 1 * Time.deltaTime;

            float shake = Mathf.Sin(Time.time * shakeSpeed) * shakeSize;

            BatteryUIHolder.transform.position = new Vector2 (BPos.x + shake,BPos.y + shake * Random.Range(-2, 2));
            
            if (Battery < 0) 
            {
                _PC.flashOff();
            }
        } else
        {
            BatteryUIHolder.transform.position = new Vector2(BPos.x, BPos.y);
        }


        BatteryUI.fillAmount = Battery / Battery2;
    }

    public void RegainPower(float _pow)
    {
        Battery += _pow;
    }
}
