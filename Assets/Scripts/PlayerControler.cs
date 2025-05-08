using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public float jumpforce;
    private bool canEnterBus = false;
    private GameObject popUp;
   // private Rigidbody2D rb;
   // private bool isGrounded;
    

    void Start()
    {
        //  rb = GetComponent<Rigidbody2D>();
        popUp = GameObject.Find("BusPopUp");
        if(popUp != null)
        {
            popUp.SetActive(false);
        }
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * HorizontalInput * Time.deltaTime);

        if (GameManager.Instance != null && !GameManager.Instance.gameStarted)
        {
            if (canEnterBus && Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.StartGame();
                Destroy(gameObject); // Optional: replace with animation
            }
            return;
        }
        

      /*  if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            isGrounded = false;
        }*/

        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BUS"))
        {
            canEnterBus = true;
            Debug.Log("Press E to enter the bus.");
            if(popUp != null)
                popUp.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BUS"))
        {
            canEnterBus = false;
            if (popUp != null)
                popUp.SetActive(false);
        }
    }


}
