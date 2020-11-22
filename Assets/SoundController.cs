using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource mainBGM;
    void Start()
    {
        mainBGM.volume = 0.15f;
        mainBGM.loop = true;
        mainBGM.Play();
    }
    public void StopBGM()
    {
        mainBGM.Stop();
    }
}
