using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    // Fix entire system to Set y Rotation to a random degree between 0 and 359
    [SerializeField] private float _rotationSpeed = 0.01f;
    private bool _canRotate = false;
 
    private float timer;
    // Start is called before the first frame update
    private void Start()
    {
        timer = Random.Range(0f,5f) + Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > timer) { _canRotate = true; }
 
        // Rotation
        if (_canRotate)
        {
            transform.eulerAngles = new Vector3(0f,transform.eulerAngles.y + _rotationSpeed, 0f);
        }
    }
}
