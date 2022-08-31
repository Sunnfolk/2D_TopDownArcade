using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float enemyMoveSpeed;
    [SerializeField] private int directionUpdateInt = 2;

    [Header("Health")] 
    [Range(0,3)]
    public int enemyHealth = 3;

    public Color _FullHealth;
    public Color _Bruised;
    public Color _Injured;
    
    private float m_Timer;
    private GameObject m_Target;
    private Transform m_TargetTrans;
    private Vector2 m_MoveDirection;

    private SpriteRenderer _spriteRenderer;
    
    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitialiseFollow();
    }

    
    private void Update()
    {
        if (enemyHealth == 3)
        {
            _spriteRenderer.color = _FullHealth;
        }
        else if (enemyHealth == 2)
        {
            _spriteRenderer.color = _Bruised;
        }
        else if (enemyHealth == 1)
        {
            _spriteRenderer.color = _Injured;
        }
        else if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
        
        /*if (Time.frameCount % frameInterval == 0)
        {
            m_MoveDirection = (transform.position - m_TargetTrans.position).normalized;
        }*/

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (Time.time > m_Timer)
        {
            m_MoveDirection = (m_TargetTrans.position - transform.position).normalized;
            m_Timer = Time.time + directionUpdateInt;
        }

        transform.Translate(m_MoveDirection * enemyMoveSpeed * Time.deltaTime);
    }

    private void InitialiseFollow()
    {
        m_Target = GameObject.Find("Player");
        m_Target.TryGetComponent(out Transform trans);
        m_TargetTrans = trans;

        m_MoveDirection = (transform.position - m_TargetTrans.position).normalized;
    }

}
