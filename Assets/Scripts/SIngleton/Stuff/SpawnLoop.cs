using UnityEngine;

public class SpawnLoop : MonoBehaviour
{
    public GameObject obj;

    public float timer;
    public float timer2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timer2 = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timer2;

            Instantiate(obj, transform.position, transform.rotation);
        }
    }
}
