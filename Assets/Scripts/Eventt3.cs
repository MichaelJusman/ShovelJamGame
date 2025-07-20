using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventt3 : MonoBehaviour
{
    public UnityEvent evemt;
    // Start is called before the first frame update
    public void PlayEvent3()
    {
        evemt.Invoke();
    }
}
