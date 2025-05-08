using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSpwaner : MonoBehaviour
{
    public GameObject CheckpointPrefab;
    public Vector3 spawnPos = new Vector3(100, 0, 0);
    public float spwanDealy;
    private EXPlayerControler playerControler;
    void Start()
    {
        playerControler = GameObject.Find("BUS").GetComponent<EXPlayerControler>();
        Invoke("CheckPointSpwan", spwanDealy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckPointSpwan()
    {
        if (GameManager.Instance.gameStarted && playerControler.gameOver == false)
        {
            Instantiate(CheckpointPrefab, spawnPos, CheckpointPrefab.transform.rotation);
        }
    }
    
}
