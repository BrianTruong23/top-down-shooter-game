using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
        
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Enemy hit the player!");
            // take damager logic 
            HUDManager hudManager = FindFirstObjectByType<HUDManager>();
            hudManager.TakeDamage(1);
        }
    }
}
