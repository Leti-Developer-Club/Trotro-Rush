using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpwaner : MonoBehaviour
{
    public GameObject[] passengerPrefab;
    private float spwanInterval = 3f;
    public float xMin = 0;
    public float yMin = 300f;
    private bool spawning = false;
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
            InvokeRepeating("SpawnPassenger", 2f, spwanInterval);
        }
    }
    void SpawnPassenger()
    {
        if (GameManager.Instance.gameover) return;
        int randomnumber = Random.Range(0, 2);
        float yRondom;
        if (randomnumber == 0)
        {
            yRondom = -6.1f;
        }
        else
        {
            yRondom = -10.8f;
        }
       
        float xRondom = Random.Range(yMin, xMin);
       
        Vector2 spwanPosition = new Vector2(xRondom,yRondom);
        int passIndex = Random.Range(0, passengerPrefab.Length);
        if (playerControler.gameOver == false)
        {
            Instantiate(passengerPrefab[passIndex], spwanPosition, Quaternion.identity);
        }
    }
}
