using UnityEngine;
using Random = UnityEngine.Random;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class CoinController : MonoBehaviour
    {
        
        // Fix entire system to Set y Rotation to a random degree between 0 and 359
        // [MinMaxSlider(0, 1)] public Vector2 test;
    
        private float m_RotationSpeed = 0.05f;
        private bool m_CanRotate;
 
        private float m_Timer;
        // Start is called before the first frame update
        private void Start()
        {
            InitialiseRotation();
        }
        

        // Update is called once per frame
        private void Update()
        {
            UpdateRotation();
        }
        private void InitialiseRotation()
        {
            int randomRotY = Random.Range(0, 180);
            int randomRotW = Random.Range(0, 180);

            transform.rotation = new Quaternion(0, randomRotY, 0, randomRotW);
         
            
            m_Timer = Random.Range(10f, 15f) + Time.time;
            m_RotationSpeed = Random.Range(0.01f, 0.1f);
        }

        private void UpdateRotation()
        {
            if (Time.time > m_Timer)
            {
                m_CanRotate = true;
            }

            // Rotation
            if (!m_CanRotate) return;

            var transform1 = transform;
            transform1.eulerAngles = new Vector3(0f, transform1.eulerAngles.y + m_RotationSpeed, 0f);
        }
    }
}