using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{   
    public void Play(){
        SceneManager.LoadScene("PrimeiraFase");
    }   
    public void Quit(){
        Application.Quit();
        Debug.Log("quit lol");
    }
}