using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public ParticleSystem Conffetti1;
    public ParticleSystem Conffetti2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Conffetti1.Play();
            Conffetti2.Play();

            GameControl.instance.player.sidespeed = 0f;
            GameControl.instance.gameOver = false;
            GameControl.instance.WinUI.SetActive(true);
        }
    }
}
