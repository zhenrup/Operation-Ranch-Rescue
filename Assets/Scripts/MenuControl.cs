using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public ItemCollector Collector;
    public GameObject gameCompleteUI;
    public Text timer;
    private float spentTime = 0;
    private bool isNotShow = true;

    // Start is called before the first frame update
    void Start()
    {
        Collector = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ItemCollector>();
        gameCompleteUI.SetActive(false);
        // start count time

    }

    // Update is called once per frame
    void Update()
    {
        spentTime += Time.deltaTime;
        // if the player get all apple
        if (Collector.getAllApple()) {
            // if the final time is not shown
            if (isNotShow) {
                showTime();
            }

            gameCompleteUI.SetActive(true);
        }
    }

    // show how much time the player used to collect all apples
    public void showTime() {
        string finalSpentTime = "in " + spentTime.ToString("0.000");
        finalSpentTime = finalSpentTime + "s";
        timer.text = finalSpentTime;
        isNotShow = false;
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
    
}
