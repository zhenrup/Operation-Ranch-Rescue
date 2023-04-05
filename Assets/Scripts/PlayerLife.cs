using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public PlayerMovement playerMove;
    public PlayerManager playerManage;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private IEnumerator coroutine;
    
    public ItemCollector Collector;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerManage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        Collector = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ItemCollector>();
    }

    void Update() {
        if (Collector.getAllApple()) {
            PauseGame();
        }
    }

    void PauseGame() {
        Time.timeScale = 0;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks the object 'tag' that is passed when the player collides with an object
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        //first, lets switch to the death animation, and make player movement static
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        Destroy(GameObject.FindWithTag("Player"), 3);
    }

    // stop a process at a specific moment for a certain amount of wait time
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
    
    // do something at the restart level
    private void RestartLevel()
    {
        // wait for 4 seconds before respawn the player
        coroutine = WaitAndPrint(3f);
        StartCoroutine(coroutine);
        playerManage.respawnAtRecentPos();
    }

}
