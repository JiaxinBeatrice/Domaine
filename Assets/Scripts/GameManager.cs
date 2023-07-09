using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cr;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tapText;

    bool isGameStarted = false;
    int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameStarted) {
            StartSpawning();
            isGameStarted = true;
            tapText.enabled = false;
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnCr", 0.5f, spawnRate);
    }

    private void SpawnCr()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(cr, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
    }
}
