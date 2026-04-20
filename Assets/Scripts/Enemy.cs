using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int currentHp;
    private void Awake()
    {
        currentHp = 1;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.TakeDamage(1);
            TakeDamage(1);
        }
    }
}
