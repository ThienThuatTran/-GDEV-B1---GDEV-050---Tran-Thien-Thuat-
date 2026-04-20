using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private float fireDuration = 0;
    private Vector3 currentTowardPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateCurrentPos();
        }
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanFire())
            {
                Fire();
            }
        }
        
    }

    private void UpdateCurrentPos()
    {
        currentTowardPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        currentTowardPos.z = 0;
        //Debug.Log(currentTowardPos);
        //TowardPosition(currentTowardPos);

    }

    private void TowardPosition(Vector3 targetPos)
    {
        transform.forward = (targetPos - transform.position).normalized;
    }

    private void Move()
    {
        float distance = Vector3.Distance(transform.position, currentTowardPos);
        if (distance > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, currentTowardPos, speed * Time.deltaTime);
        }
    }

    private bool CanFire()
    {
        if (Time.time > fireDuration)
        {
            fireDuration = Time.time + fireDelay;
            return true;
        }
        else return false;
    }
    private void Fire()
    {
        var direction = transform.forward;

        var bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletObject.GetComponent<Bullet>().Init(direction);
    }
}
