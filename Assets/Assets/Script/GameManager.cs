using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 2.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private int score = 0;
    private bool gameActive = false;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void StartGame()
    {
        gameActive = true;
        score = 0;
    }
    public void StartGame(int diff)
    {
        gameActive = true;
        score = 0;
        spawnRate /= Diff;
        Debug.Log("Game spawn rate = " + spawnRate);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        gameActive = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }
    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
