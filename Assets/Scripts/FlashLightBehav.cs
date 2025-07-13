using UnityEngine;

public class FlashLightBehav : MonoBehaviour
{
    public GameObject FLight;
    public float lightDist;
    public float Dampning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lightDist));


        FLight.transform.rotation = Quaternion.FromToRotation(FLight.transform.forward, FLight.transform.position - pos) * FLight.transform.rotation;
    }
}
