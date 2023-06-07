using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;

    public static UIManager Instance 
    { 
        get
        {
            return _instance;
        }
    }
}
