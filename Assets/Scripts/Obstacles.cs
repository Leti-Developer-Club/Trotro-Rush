using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float timePenalty = 2.0f;
    public int farePenalty = 1;
    public float movespeed;
    private float xBound = -60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector2.left * movespeed * Time.deltaTime);
        if (gameObject.CompareTag("Obstacle") && transform.position.x <xBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BUS"))
        {
            EXPlayerControler Bus = collision.GetComponent<EXPlayerControler>();
            if (Bus != null)
            {
                Bus.timer -= timePenalty;
                Bus.fareCount = Mathf.Max(0,Bus.fareCount - farePenalty);
                Debug.Log("Hit a Obstacle  - Time Reduced: " + timePenalty + "s, Fares Reduced: " + farePenalty);
              
            }
            if (!Bus.hasluckyCharm)
            {
                Bus.LoseFare();
            }
            else
            {
                Debug.Log("Lucky Charm protected player");
            }
        }
    }
}
