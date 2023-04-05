using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;

    public Text applesText;

    public void addScore(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            apples++;
            applesText.text = "Apples: 0" + apples;
            Destroy(collision.gameObject);

        }
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    // prompt the player to game completion once they collected three apples
    public bool getAllApple() {
        return apples == 1;
    }

}
