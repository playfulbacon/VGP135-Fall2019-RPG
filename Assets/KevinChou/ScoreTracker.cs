using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    Text mText;
    int score = 0;
    public int prevEnemiesCount = 0;
    public int currentEnemiesCount = 0;
    bool firstRun = false;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstRun)
        {
            currentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (prevEnemiesCount > currentEnemiesCount)
            {
                score += 1;
            }
            prevEnemiesCount = currentEnemiesCount;
            mText.text = "Score: " + score.ToString();
        }
    }

    private void LateUpdate()
    {
        if(!firstRun)
        {
            firstRun = true;
            prevEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            currentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
    }
}
