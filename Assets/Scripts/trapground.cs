using UnityEngine;

public class trapground : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D _collider;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            rb.gravityScale = 1;
            _collider.enabled = false;
        }
    }
}
