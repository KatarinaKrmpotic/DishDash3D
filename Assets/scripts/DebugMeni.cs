using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMeni : MonoBehaviour

{
    public TMP_InputField PlayerSpeedInputField;
    public TMP_InputField PlayerSideSpeedInputField;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        PlayerSpeedInputField.onValueChanged.AddListener(OnPlayerSpeedValueChange);
        PlayerSideSpeedInputField.onValueChanged.AddListener(OnPlayerSideSpeedValueChange);

        GameControl.instance.player.speed = PlayerPrefs.GetFloat("speed", GameControl.instance.player.speed);
        GameControl.instance.player.sidespeed = PlayerPrefs.GetFloat("sidespeed", GameControl.instance.player.sidespeed);

        PlayerSpeedInputField.placeholder.GetComponent<TMP_Text>().text = GameControl.instance.player.speed.ToString();
        PlayerSideSpeedInputField.placeholder.GetComponent<TMP_Text>().text = GameControl.instance.player.sidespeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPlayerSpeedValueChange(string val)
    {
        float speed = GameControl.instance.player.speed;
        if (float.TryParse(val, System.Globalization.NumberStyles.Float, null, out speed))
        {
            speed = Mathf.Clamp(speed,5,30);
            GameControl.instance.player.speed = speed;
            PlayerPrefs.SetFloat("speed", speed);
        }


    }

    void OnPlayerSideSpeedValueChange(string val)
    {
        float sidespeed = GameControl.instance.player.sidespeed;
        if (float.TryParse(val, System.Globalization.NumberStyles.Float, null, out sidespeed))
        {
            sidespeed = Mathf.Clamp(sidespeed,5,30);
            GameControl.instance.player.sidespeed = sidespeed;
            PlayerPrefs.SetFloat("sidespeed", sidespeed);
        }
    }


    public void ResetButton()
    {
        GameControl.instance.player.speed = 10f;
        GameControl.instance.player.sidespeed = 20f;

        PlayerPrefs.SetFloat("speed", 10f);
        PlayerPrefs.SetFloat("sidespeed", 20f);

        PlayerSpeedInputField.text = "10";
        PlayerSideSpeedInputField.text = "20"; 


    }
}
