using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 10f;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void Init(Vector3 direction)
    {
        this.direction = direction;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        //Debug.Log(direction);
        transform.position += direction * speed * Time.deltaTime;
        //Debug.Log(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            //Debug.Log("hit enemy");
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
