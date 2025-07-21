using UnityEngine;

public class easteregg : MonoBehaviour
{
    public int range = 4;
    public GameObject obj;
    public bool once = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rand()
    {
        int ran = Random.Range(0, range);

        print(ran);

        if (ran == 0 && once == false)
        {
            obj.SetActive(true);
            once = true;
        }
    }
}
