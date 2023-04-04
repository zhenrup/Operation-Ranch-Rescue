using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public Vector2 initalSpawnPos = new Vector2(2.82f, 6.31f);
    public PlayerLife life;
    public PlayerMovement playerMove;
    public LinkCamera CameraManager;
    private Vector2[] spawnPosList = new Vector2[9];

    // Start is called before the first frame update
    void Start()
    {
        respawnPlayer(initalSpawnPos);
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        CameraManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<LinkCamera>();
        // need to add all available spawn location
        spawnPosList = new Vector2[9]{new Vector2(2.82f, 6.32f), new Vector2(26.19f, 2.3f),
                                        new Vector2(48.23f,3.39f), new Vector2(65.12f, 12.19f),
                                        new Vector2(25.28f, 13.16f), new Vector2(17.39f, 11.28f),
                                        new Vector2(21.15f, 21.18f), new Vector2(41.49f, 21.24f),
                                        new Vector2(51.99f, 21.36f)};
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // get player location when they exit the triiger
    public void respawnPlayer(Vector2 spawnPos) {
        Instantiate(player, spawnPos, transform.rotation);
    }



    public void respawnAtRecentPos() {
        int spawnRoom = CameraManager.getPrevRoom();
        respawnPlayer(spawnPosList[spawnRoom - 1]);
    }
}
