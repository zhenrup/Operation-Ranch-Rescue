using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
       animator = GetComponent<Animator>();
    }

    public void BreakChest()
    {
        // Debug.Log("Chest is now broken...");
        animator.SetBool("broken", true);
    }   
}
