using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Sunnfolk_Complete.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public int score;
        public int goal = 10;
        [Space(5f)]
    
        public float speed = 3f;
        public bool normaliseInput = true;
        public bool relativeProjectileSpeed = true;
        
        [SerializeField] private GameObject projectile;
        [SerializeField] private float shootTimeBuffer;
        private float _mShootTimer;
        private Vector2 _mMoveVector;
        private Vector2 _mShootVector;

        public Vector2 move;

        private void Start()
        {
            score = 0;
            _mShootVector = Vector2.right;
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateMovement();
            UpdateGoalManager();
            UpdateShooting();
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            UpdatePickup(col);
            
            if (col.transform.CompareTag($"Enemy"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        private void UpdatePickup(Collider2D col)
        {
            print($"I Collided with {col.transform.name}");
        
            if (!col.transform.CompareTag($"Complete/Coin")) return;
        
            score++;
            Destroy(col.gameObject);
        }

        private void UpdateShooting()
        {
            if (_mMoveVector != Vector2.zero)
            {
                _mShootVector = _mMoveVector;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time > _mShootTimer)
            {
                var clone = Instantiate(projectile, transform.position, quaternion.identity);
                clone.TryGetComponent(out ProjectileController projectileC);
                projectileC.direction = _mShootVector;

                projectileC.relativeSpeed = relativeProjectileSpeed && _mMoveVector != Vector2.zero ? move : Vector2.zero;


                Destroy(clone, 2f);
                _mShootTimer = Time.time + shootTimeBuffer;
            }
        }

        private void UpdateGoalManager()
        {
            // CHECK IF SCORE IS GREATER OR EQUAL TO GOAL
            if (score < goal) return;
        
            score = 0;
           // SceneManager.LoadScene($"EndScreen");
        }

        private void UpdateMovement()
        {
            // GET INPUT
            _mMoveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
            _mMoveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

            // NORMALISE Vector INPUT
            if (normaliseInput && _mMoveVector.magnitude > 1)
            {
                _mMoveVector = _mMoveVector.normalized;
            }

            // APPLY INPUT & SPEED TO MOVEMENT
            move = _mMoveVector * speed;
            transform.Translate(move * Time.deltaTime);
        
        }
    }
}