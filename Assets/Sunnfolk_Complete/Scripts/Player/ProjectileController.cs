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
            if (col.transform.CompareTag($"Enemy"))
            {
                col.TryGetComponent(out EnemyController controller);
                controller.enemyHealth--;
            }
            
            // NO CODE BELOW THIS POINT
            if (col.CompareTag("Player") || col.CompareTag($"Complete/Coin")) return;
                Destroy(gameObject);
        }
    }
}
