using UnityEngine;
using Random = UnityEngine.Random;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class CoinController : MonoBehaviour
    {
        private float _rotationSpeed = 0.05f;
        private float _timer;
        
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
            Vector2Int randomRot = new Vector2Int(Random.Range(0, 180), Random.Range(0, 180));
        
            transform.rotation = new Quaternion(0, randomRot.x, 0, randomRot.y);

            _timer = Random.Range(0f, 0.3f) + Time.time;
            _rotationSpeed = Random.Range(0.01f, 0.1f);
        }

        private void UpdateRotation()
        {
            if (Time.time > _timer) return;

                var transform1 = transform;
            transform1.eulerAngles = new Vector3(0f, transform1.eulerAngles.y + _rotationSpeed, 0f);
        }
    }
}