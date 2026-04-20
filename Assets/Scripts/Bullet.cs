using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 10f;
    public void Init(Vector3 direction)
    {
        this.direction = direction;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
