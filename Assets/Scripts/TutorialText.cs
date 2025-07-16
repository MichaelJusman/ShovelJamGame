using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public Color ColorStart, ColorEnd;

    public float weight;

    public TextMeshProUGUI TXTt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TXTt.color = Color.Lerp(ColorStart, ColorEnd, weight);
    }
}
