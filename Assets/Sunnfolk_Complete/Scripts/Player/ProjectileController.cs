using Sunnfolk_Complete.Scripts.Enemy;
using UnityEngine;

namespace Sunnfolk_Complete.Scripts.Player
{
    public class ProjectileController : MonoBehaviour
    {
        public Vector2 direction;
        public float projectileSpeed;
        public Vector2 relativeSpeed;

        private void Update()
        {
            var baseSpeed = (direction * projectileSpeed);
            transform.Translate((baseSpeed + relativeSpeed) * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.CompareTag($"Complete/Coin"))
            {
                Destroy(col.gameObject);
            
                Destroy(gameObject);
            }

            if (col.transform.CompareTag("Enemy"))
            {
                col.TryGetComponent(out EnemyController controller);
                controller.enemyHealth--;
                Destroy(gameObject);
            }
        }
    }
}
