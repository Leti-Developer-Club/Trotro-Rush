using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType {SpeedBoost,LuckyCharm,ExtraPoints }
    public PowerUpType powerUp;
    private float duration =5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.Instance.gameStarted || GameManager.Instance.gameover) return;
        if (collision.CompareTag("BUS") )
        {
              EXPlayerControler player = collision.GetComponent<EXPlayerControler>();
               

            switch(powerUp)
            {
                case PowerUpType.SpeedBoost:
                    ActivateSpeedBoost(duration);
                    break;
                case PowerUpType.LuckyCharm:
                    player.ActivateLuckyCharm(duration); 
                    break;
                case PowerUpType.ExtraPoints:
                    player.ExtraFair();
                    break;
            }
            Destroy(gameObject);
        }
    }
    void ActivateSpeedBoost(float boostDuration)
    {
        // Find all MoveLeft objects in the scene and apply the speed boost
        MoveLeft[] movingObjects = FindObjectsOfType<MoveLeft>();

        foreach (MoveLeft obj in movingObjects)
        {
            obj.ActivateSpeedBoost(2f, boostDuration);  // Speed up all moving objects
        }
    }
}
