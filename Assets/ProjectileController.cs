using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector2 direction;
    public float projectileSpeed;

    private void Update()
    {
        transform.Translate(direction * (projectileSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag($"Complete/Coin"))
        {
            Destroy(col.gameObject);
            
            Destroy(gameObject);
        }
    }
}
