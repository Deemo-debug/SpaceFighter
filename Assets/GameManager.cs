using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float spawnRate;
    float timer;

    public GameObject enemyPrefab;
    public Transform enemyHolder;
    public GameObject gameOverPanel;
    public GameObject gameStartPanel;

    bool isPlaying = true;

    private void Start()
    {
        gameStartPanel.SetActive(true);
        isPlaying = false;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying)
            return;

        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            timer = 0;
            SpawnNewEnemy();
        }
    }

    void SpawnNewEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-28f, 28f), 12.5f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.transform.parent = enemyHolder;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isPlaying = false;
        FindObjectOfType<PlayerController>().gameObject.SetActive(false);
        Destroy(enemyHolder.gameObject);
    }

    public void GameStart()
    {
        isPlaying = true;
        gameStartPanel.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
