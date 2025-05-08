using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector2 spwanPos;
    public float xPos;
    public float startdealy;
    public float respwanDealy;
    private bool spawning;
    private EXPlayerControler playerControler;
    // Start is called before the first frame update
    void Start()
    {
       
        playerControler = GameObject.Find("BUS").GetComponent<EXPlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStarted && !spawning)
        {
            spawning = true;
            InvokeRepeating("SpawnObstacle", startdealy, respwanDealy);
        }
    }
    void SpawnObstacle() 
    {
        if (GameManager.Instance.gameover) return;
        int position = Random.Range(0, 2);
        float yRandom;
        if (position == 0)
        {
            yRandom = -8.55f;
        }
        else
        {
            yRandom = -11.5f;
        }
        spwanPos = new Vector2(xPos , yRandom);
        int obstIndex = Random.Range(0, obstaclePrefab.Length);
        if (playerControler.gameOver == false)
        {
            Instantiate(obstaclePrefab[obstIndex], spwanPos, Quaternion.identity);
        }
    }

}
