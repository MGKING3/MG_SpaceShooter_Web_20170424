using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public List<GameObject> asteroidPrefabs;
    public Vector3 createAsteroidArea;
    public float startWaitTime;
    public float offsetWaitTime;
    public int countPerCycle;
    public float cycleWaitTime;
    public Text scoreText;
    private int scoreValue;
    private bool isGameOver;
    private bool isRestart;
    public Text gameOverText;
    public Text restartText;

    private void Start()
    {
        scoreValue = 0;
        isGameOver = false;
        isRestart = false;
        gameOverText.enabled = false;
        restartText.enabled = false;
        StartCoroutine(CreateAsteroid());//开启协程生成小行星
    }

    private void Update()
    {
        if (isRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        scoreValue += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.enabled = true;
    }

    private IEnumerator CreateAsteroid()
    {
        yield return new WaitForSeconds(startWaitTime);//等待若干时间后开始循环生成小行星
        while (true)
        {
            for (int i = 0; i < countPerCycle; i++)
            {
                Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Count)],
                    new Vector3(Random.Range(-createAsteroidArea.x, createAsteroidArea.x), createAsteroidArea.y, createAsteroidArea.z),
                    Quaternion.identity);
                yield return new WaitForSeconds(offsetWaitTime);//等待若干时间后生成下一个小行星
            }
            yield return new WaitForSeconds(cycleWaitTime);//等待若干时间后生成下一轮小行星
            if (isGameOver)
            {
                isRestart = true;
                restartText.enabled = true;
                break;
            }
        }
    }
}
