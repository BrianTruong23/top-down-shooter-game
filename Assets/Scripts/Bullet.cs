using UnityEngine;


public class Bullet : MonoBehaviour
{
    float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HUDManager hudManager = FindFirstObjectByType<HUDManager>();
            hudManager.AddScore(1);

            // play enemy death sound here

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
