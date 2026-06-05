using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5f;
    Vector2 moveInput;

    float minX = -10.5f;
    float maxX = 10.5f;
    float minY = -5.5f;
    float maxY = 0f;

    float fireRate = 0.5f;
    float nextFireTime = 0f;

    public AudioSource audioSource;
    public AudioClip shootClip;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public void OnAttack()
    {
        if (Time.time >= nextFireTime)
        {
            audioSource.PlayOneShot(shootClip);
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
