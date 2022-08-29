//using GD.MinMaxSlider;

using UnityEngine;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class CoinRotation : MonoBehaviour
    {
        // Fix entire system to Set y Rotation to a random degree between 0 and 359
        // [MinMaxSlider(0, 1)] public Vector2 test;
    
        private float m_RotationSpeed = 0.05f;
        private bool m_CanRotate;
 
        private float m_Timer;
        // Start is called before the first frame update
        private void Start()
        {
            m_Timer = Random.Range(0f,1f) + Time.time;
            m_RotationSpeed = Random.Range(0.01f, 0.1f);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time > m_Timer) { m_CanRotate = true; }
 
            // Rotation
            if (!m_CanRotate) return;
        
            var transform1 = transform;
            transform1.eulerAngles = new Vector3(0f,transform1.eulerAngles.y + m_RotationSpeed, 0f);
        }
    }
}
