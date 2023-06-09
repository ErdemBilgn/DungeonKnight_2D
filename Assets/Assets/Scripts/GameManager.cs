using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Instance
    {
        get 
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is null!!");
            }
            return _instance;
        }
    }

    public bool HasKeyToCaste { get; set; }

    void Awake()
    {
        _instance = this;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
