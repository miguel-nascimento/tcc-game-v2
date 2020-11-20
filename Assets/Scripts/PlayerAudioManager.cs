﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource footsteps;

    [SerializeField]
    private AudioSource airHit;

    [SerializeField]
    private AudioSource enemyHit;
    // Start is called before the first frame update
    public void playFootsteps()
    {
        footsteps.volume = Random.Range(0.4f,0.8f);
        footsteps.pitch = Random.Range(1f,1.2f);
        footsteps.Play();
    }

    public void playAirHit()
    {
        airHit.pitch = Random.Range(1.10f,1.3f);
        airHit.volume = Random.Range(0.3f,0.6f);
        airHit.Play();
    }

    public void playEnemyHit()
    {
        enemyHit.volume = Random.Range(0.05f,0.2f);
        enemyHit.pitch = Random.Range(1.50f,1.7f);
        enemyHit.Play();
    }
}
