using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour
{
    public float pushForce = 10f;
    private bool isPushed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPushed && collision.gameObject.CompareTag("BUS"))
        {
            isPushed = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (transform.position - collision.transform.position).normalized;
                rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
            }

            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
