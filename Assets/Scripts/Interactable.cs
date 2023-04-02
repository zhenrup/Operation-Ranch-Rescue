using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactionAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            interactionAction.Invoke();
            Debug.Log("Chest should now be broken");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            isInRange = false;
    }
}
