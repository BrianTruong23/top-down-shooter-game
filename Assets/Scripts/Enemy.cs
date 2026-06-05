using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float waveAmount;
    public float waveSpeed;
    public Vector3 moveDirection = Vector3.right;
    float startY;
    public GameObject bulletPrefab;
    public Transform EnemyFirePoint;
    float nextFireTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = Random.Range(1f, 3f);
        waveAmount = Random.Range(0.5f, 1.5f);
        waveSpeed = Random.Range(1f, 3f);
        startY = transform.position.y;
        nextFireTime = Time.time + Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float Y = startY + Mathf.Sin(Time.time * waveSpeed) * waveAmount;
        transform.position = new Vector3(transform.position.x, Y, transform.position.z);

        if (transform.position.x > 11f || transform.position.x < -11f)
        {
            Destroy(gameObject);
        }

        if (Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, EnemyFirePoint.position, Quaternion.Euler(0f, 0f, 180f));
            nextFireTime = Time.time + Random.Range(1f, 3f);
        }
        
    }


}
