using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{   
    public GameObject playSelector;
    public GameObject quitSelector;
    public GameObject play;


    public void Play(){
        SceneManager.LoadScene("PrimeiraFase");
    }   
    public void Quit(){
        Application.Quit();
        Debug.Log("quit lol");
    }

    void Update(){
        Switcher();
    }
    public void Switcher(){
        GameObject current = EventSystem.current.currentSelectedGameObject;
        if (current == play){
            playSelector.SetActive(true);
            quitSelector.SetActive(false);
        } else {
            playSelector.SetActive(false);
            quitSelector.SetActive(true);
        }
    }
}