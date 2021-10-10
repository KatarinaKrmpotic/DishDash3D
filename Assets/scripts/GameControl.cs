using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public bool gameStarted = false;
    public bool gameOver = false;
    public PlayerMovement player;

    public bool isPaused;
    public GameObject StartUI;
    public GameObject LoseUI;
    public GameObject WinUI;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("runner");
    }

    public void Pause ()
    {
        isPaused = true;
        
    }

    public void unPause()
    {
        isPaused = false;
    }
}
