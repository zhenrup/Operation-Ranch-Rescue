using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public PlayerMovement playerMove;
    public PlayerManager playerManage;
    private Animator animator;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerManage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
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
        Destroy(GameObject.FindWithTag("Player"));

        playerManage.respawnAtRecentPos();
    }
    // do something at the restart level
    private void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
