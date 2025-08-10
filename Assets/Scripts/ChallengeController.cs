using UnityEngine;

public class ChallengeController : GameBehaiour
{
    public bool rain;
    public bool aggressive;
    public bool Battery;
    public bool rando;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("rainn", 0);
        PlayerPrefs.SetInt("agro", 0);
        PlayerPrefs.SetInt("batt", 0);
        PlayerPrefs.SetInt("rando", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void storm(bool _val)
    {
        rain = _val;
        if (rain == true)
        {
            PlayerPrefs.SetInt("rainn", 1);
        } else
        {
            PlayerPrefs.SetInt("rainn", 0);
        }
        
    }
    public void aggro(bool _val)
    {
        aggressive = _val;
        if (aggressive == true)
        {
            PlayerPrefs.SetInt("agro", 1);
        }
        else
        {
            PlayerPrefs.SetInt("agro", 0);
        }
    }
    public void batt(bool _val)
    {
        Battery = _val;
        if (Battery == true)
        {
            PlayerPrefs.SetInt("batt", 1);
        }
        else
        {
            PlayerPrefs.SetInt("batt", 0);
        }
    }
    public void rano(bool _val)
    {
        rando = _val;
        if (rando == true)
        {
            PlayerPrefs.SetInt("rando", 1);
        }
        else
        {
            PlayerPrefs.SetInt("rando", 0);
        }
    }

}
