using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EXPlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public float verticalInput;
    public float horizontalInput;
    public TextMeshProUGUI fareText;
    public TextMeshProUGUI timerText;
    public int fareCount;
    public float timer;
    public bool gameOver = false;

    public float yAxisBorderMin;
    public float yAxisBorderMax;

    public bool hasluckyCharm = false;

    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        UpdateFairText();
        UpdateTimerText();
        if (uiManager == null)
        {
            uiManager = GameObject.FindObjectOfType<UIManager>();
        }
        if (uiManager == null)
        {
            Debug.LogWarning("UIManager not found in the scene.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameStarted || gameOver) return;
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.up *  moveSpeed * verticalInput * Time.deltaTime);
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            timer = 0;
            Debug.Log("Game Over Time Up.");
            gameOver = true;
            if (uiManager != null)
            {
                uiManager.ShowGameOverUI();
            }
        }
        if (transform.position.y < yAxisBorderMax)
        {
            transform.position = new Vector2(transform.position.x, -11.4f);
        }
        if(transform.position.y > yAxisBorderMin)
        {
            transform.position = new Vector2(transform.position.x, -7.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Passenger"))
        {
            fareCount++;  // increase fair 
            Destroy(collision.gameObject); // destroy passenger
            Debug.Log("Fair Collected Total :" + fareCount);
            UpdateFairText();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            if (!hasluckyCharm)
            {
                LoseFare();
                Debug.Log("Hit an Obstacle! Lost a fare.");
            }
            else
            {
                Debug.Log("Lucky Charm is activated No fare will Lose");
            }
        }
        else if (collision.CompareTag("CheckPoint"))
        {
            Debug.Log("Level Completed");
            gameOver = true;
        }
        
    }
    void UpdateFairText()
    {
        fareText.text = "Fair:0" + fareCount;
    }
    void UpdateTimerText()
    {
        timerText.text = "Time:" + Mathf.Ceil(timer);
    }
   
    public void ActivateLuckyCharm(float duration)
    {
        StartCoroutine(LuckyCharmCoroutine(duration));
    }
    private IEnumerator LuckyCharmCoroutine(float duration)
    {
        hasluckyCharm = true;
        Debug.Log("Lucky Charm Activated! Protection for " + duration + " seconds.");
        yield return new WaitForSeconds(duration);
        hasluckyCharm = false;
        Debug.Log("Lucky Charm Expired!");
    }
   public void LoseFare()
    {
        if (fareCount > 0)
        {
            fareCount--;
            Debug.Log("Fare Lost! Remaining: "+ fareCount);
            UpdateFairText();
        }
    }
    public void ExtraFair()
    {
        fareCount += 5;
        UpdateFairText();
    }
   
    
}
