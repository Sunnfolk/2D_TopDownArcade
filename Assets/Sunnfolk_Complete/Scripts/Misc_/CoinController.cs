using UnityEngine;
using Random = UnityEngine.Random;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class CoinController : MonoBehaviour
    {
        public float rotationSpeed = 0.1f;
        
        private void Start()
        {
            InitialiseRotation();
        }
       
        private void Update()
        {
            UpdateRotation();
        }

        private void InitialiseRotation()
        {
            float randomRotX = Random.Range(0, 180);
            float randomRotY = Random.Range(0, 180);
        
            transform.rotation = new Quaternion(0, randomRotX, 0, randomRotY);
            //_rotationSpeed = Random.Range(0.01f, 0.9f);
        }

        private void UpdateRotation()
        {
            var transform1 = transform;
            transform1.eulerAngles = new Vector3(0f, transform1.eulerAngles.y + rotationSpeed, 0f);
        }
    }
}