using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireDelay = 0.5f;
    private float fireDuration = 0;
    private Vector3 currentTowardPos;
    private MapManager mapManager;

    private int currentHp;
    private void Start()
    {
        mapManager = MapManager.Instance;
        currentHp = 3;
    }
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
        var horizontal = MapManager.Instance.GetHorizontalBoundary();
        if (currentTowardPos.x > mapManager.GetAboveBoundary())
        {
            currentTowardPos.x = mapManager.GetAboveBoundary();
        }

        currentTowardPos.x = Mathf.Clamp(currentTowardPos.x, mapManager.GetBelowBoundary(), mapManager.GetAboveBoundary());
        currentTowardPos.y = Mathf.Clamp(currentTowardPos.y, mapManager.GetLeftBoundary(), mapManager.GetRightBoundary());

        currentTowardPos.z = 0;
        //Debug.Log(currentTowardPos);
        TowardPosition(currentTowardPos);

    }

    private void TowardPosition(Vector3 targetPos)
    {
        transform.up = (targetPos - transform.position).normalized;
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
        var direction = transform.up;

        var bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletObject.GetComponent<Bullet>().Init(direction);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Destroy(gameObject);
        }


    }
}
