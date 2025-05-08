using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpwaner : MonoBehaviour
{
    public GameObject[] powerUPPrefab;
    private Vector2 spwanPos;
    public float xPos;
    public float startdealy;
    public float respwanDealy;
    private EXPlayerControler playerControler;
    private bool spawning = false;
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
            InvokeRepeating("SpawnPowerUp", startdealy, respwanDealy);
        }
    }
    void SpawnPowerUp()
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
        spwanPos = new Vector2(xPos, yRandom);
        int powerIndex = Random.Range(0, powerUPPrefab.Length);
        if (playerControler.gameOver == false)
        {
            Instantiate(powerUPPrefab[powerIndex], spwanPos, Quaternion.identity);
        }
    }
}
