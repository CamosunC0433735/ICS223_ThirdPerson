using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] Vector3 respawnPos;
    [SerializeField] private float respawnFallDistance = 10f;

    private void Start()
    {
        if(respawnPos == null)
            respawnPos = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -(respawnFallDistance))
            player.GetComponent<PlayerMovement>().Respawn(respawnPos);
    }
}
