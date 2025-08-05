using UnityEngine;
using UnityEngine.Events;

public class MinigameSetup : MonoBehaviour
{
    public GameObject point;
    public float diffuculty;

    public float multiplier = 1;

    public UnityEvent evemt;

    public void updateGame()
    {
        diffuculty = diffuculty * multiplier;

        evemt.Invoke();
    }
}
