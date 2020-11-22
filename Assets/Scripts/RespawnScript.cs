using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _respawnPoint;
    public GameObject respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    // Update is called once per frame
    public void ChangeRespawn()
    {
        _respawnPoint = respawnPoint.transform;
    }

    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, _respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }
}
