using UnityEngine;
using UnityEngine.UI;

public class FlashLightBehav : GameBehaiour
{
    public bool drain;

    public GameObject FLight;
    public float lightDist;
    public float Dampning;

    public float Battery;
    private float Battery2;

    public Image BatteryUI;

    public AudioSource Baudio;
    public AudioSource Baudio2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Battery2 = Battery;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lightDist));


        FLight.transform.rotation = Quaternion.FromToRotation(FLight.transform.forward, FLight.transform.position - pos) * FLight.transform.rotation;

        if (_PC.FOn == true && drain == true)
        {
            Battery -= 1 * Time.deltaTime;  

            if (Battery < 0) 
            {
                _PC.flashOff();
            }
        }

        BatteryUI.fillAmount = Battery / Battery2;
    }
}
