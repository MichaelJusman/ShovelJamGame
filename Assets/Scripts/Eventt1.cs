using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventt1 : MonoBehaviour
{
    public UnityEvent evemt;
    // Start is called before the first frame update
    public void PlayEvent1()
    {
        evemt.Invoke();
    }
}
