using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene_EventCollider : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bossObject;
    Boss boss;
    void Start()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        boss = bossObject.GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        // checa o colisor
        // se o player passar, ativa a função do boss de On
        // destroi esse gameobject depois
    }
}
