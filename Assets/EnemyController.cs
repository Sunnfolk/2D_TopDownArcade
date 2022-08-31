using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed;
    [SerializeField] private int frameInterval = 20;
    private float m_Timer;
    private GameObject m_Target;
    private Transform m_TargetTrans;
    private Vector2 m_MoveDirection;
    
    
    public void Start()
    {
        m_Target = GameObject.Find("Player");
        m_Target.TryGetComponent(out Transform trans);
        m_TargetTrans = trans;
        
        m_MoveDirection = (transform.position - m_TargetTrans.position).normalized;
    }


    private void Update()
    {

        /*if (Time.frameCount % frameInterval == 0)
        {
            m_MoveDirection = (transform.position - m_TargetTrans.position).normalized;
        }*/

        if (Time.time > m_Timer)
        {
            m_MoveDirection = (m_TargetTrans.position - transform.position).normalized;
            m_Timer = Time.time + frameInterval;

        }
        
        transform.Translate(m_MoveDirection*enemyMoveSpeed*Time.deltaTime);
    }
}
