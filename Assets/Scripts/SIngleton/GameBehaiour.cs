using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaiour : MonoBehaviour
{
    //protected static GameManager _GM { get { return GameManager.instance; } }
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static PlayerController _PC { get { return PlayerController.instance; } }
    protected static EnemyBehav _EB { get { return EnemyBehav.instance; } }
    protected static Tutorial _TT { get { return Tutorial.instance; } }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
