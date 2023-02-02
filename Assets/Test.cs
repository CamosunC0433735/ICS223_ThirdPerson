using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10)
        {
            player.GetComponent<PlayerMovement>().Respawn(startPos);
        }
    }
}
