using UnityEngine;

public class TutorialToggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialOn()
    {
        PlayerPrefs.SetFloat("hasCompletedTutorial", 0);
    }
    public void TutorialOff()
    {
        PlayerPrefs.SetFloat("hasCompletedTutorial", 1);
    }
}
