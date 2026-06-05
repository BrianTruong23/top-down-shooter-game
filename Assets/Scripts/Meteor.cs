using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    float moveSpeed;
    Transform player; 
    Vector3 moveDirection; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = Random.Range(1f, 2f);
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
            moveDirection = (player.position - transform.position).normalized;

        }
        else
        {
            moveDirection = Vector3.down; // default to moving down if player not found
        }

    }

    // Update is called once per frame
    void Update()

    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // reload when meteor hits the player
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
            Debug.Log("Meteor hit the player!");
                      
        }
    }
}
