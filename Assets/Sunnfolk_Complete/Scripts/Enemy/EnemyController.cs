using Sunnfolk_Complete.Scripts.Misc_;
using UnityEngine;

namespace Sunnfolk_Complete.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float enemyMoveSpeed;
        [SerializeField] private int directionUpdateInt = 2;

        [Header("Follow")] public float lookRadius;
        
        [Header("Health")] 
        [Range(0,3)]
        public int enemyHealth = 3;

        public Color fullHealth;
        public Color bruised;
        public Color injured;

        public Color[] healthState;
    
        private float _timer;
        private GameObject _target;
        private Vector2 _moveDirection;
        

        private SpriteRenderer _spriteRenderer;
        private GameController _gameController;
    
        public void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            GameObject.Find("GameController").TryGetComponent(out GameController gameController);
            _gameController = gameController;
        
            InitialiseFollow();
        }

    
        private void Update()
        {
            
            // This code Updates the code within Every X Frame
            /*if (Time.frameCount % frameInterval == 0)
            {
              m_MoveDirection = (transform.position - m_TargetTrans.position).normalized;
            }*/
            UpdateHealth();
            UpdateMovement();
        }

        private void UpdateHealth()
        {
            /*
            for (int i = 2; i < healthState.Length; i++)
            {
                if (enemyHealth == i)
                {
                    _spriteRenderer.color = healthState[i];
                }
            }
            */

            if (enemyHealth == 3)
            {
                _spriteRenderer.color = fullHealth;
            }
            else if (enemyHealth == 2)
            {
                _spriteRenderer.color = bruised;
            }
            else if (enemyHealth == 1)
            {
                _spriteRenderer.color = injured;
            }
            else
            {
                _gameController.enemyNumber--;
                Destroy(gameObject);
            }
        }

        private void UpdateMovement()
        {
            if (Time.time > _timer)
            {
                _moveDirection = (_target.transform.position - transform.position).normalized;
                _timer = Time.time + directionUpdateInt;
            }
            
            var distance = Vector2.Distance(_target.transform.position, transform.position);
            if (distance > lookRadius) return;
            
            transform.Translate(_moveDirection * (enemyMoveSpeed * Time.deltaTime));
        }

        private void InitialiseFollow()
        {
            _target = GameObject.FindWithTag("Player");
            _moveDirection = (_target.transform.position - transform.position).normalized;
        }

    }
}
