using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quitting : MonoBehaviour
{
    public string scenee;

    public TextMeshProUGUI quitung;
    public float treshth = 3;
    public float amoun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            amoun += 1 * Time.deltaTime;
            quitung.enabled = true;
            if (amoun > treshth)
            {
                SceneManager.LoadScene(scenee);
            }
        } else
        {
            amoun = 0;
            quitung.enabled = false;
        }
    }
}
