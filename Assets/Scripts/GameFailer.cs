using UnityEngine;
using UnityEngine.Events;

public class GameFailer : MonoBehaviour
{
    public UnityEvent Fail;
    // Start is called before the first frame update
    public void FailGame()
    {
        Fail.Invoke();
    }
}
