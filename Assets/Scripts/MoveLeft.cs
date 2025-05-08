using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveLeft =20;
    private EXPlayerControler playerControler;
    private float indexBound =-50f;
    private float defaultSpeed;
    private bool isSpeedBoostActive;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = moveLeft;
        playerControler = GameObject.Find("BUS").GetComponent<EXPlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameStarted || GameManager.Instance.gameover) return;
        if (playerControler.gameOver == false)
        {
            transform.Translate(Vector2.left * moveLeft * Time.deltaTime);
        }
        
        if(gameObject.CompareTag("Passenger") && transform.position.x<indexBound)
        {
            Destroy(gameObject);
        }
    }

    public void ActivateSpeedBoost(float boostMultiplier, float duration)
    {
        if (!isSpeedBoostActive)  
        {
            isSpeedBoostActive = true;
            moveLeft *= boostMultiplier;
            StartCoroutine(ResetSpeedAfterDelay(duration));
        }
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveLeft = defaultSpeed; 
        isSpeedBoostActive = false;
    }

}
