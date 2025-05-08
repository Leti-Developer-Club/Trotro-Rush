using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat : MonoBehaviour
{
    private Vector2 startposition;
    private float backgroundwidth=157.5f;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Only check for background looping if the game has started
        if (!GameManager.Instance.gameStarted) return;
        if (transform.position.x < startposition.x - backgroundwidth)
        {
            transform.position = startposition;
        }
    }
}
