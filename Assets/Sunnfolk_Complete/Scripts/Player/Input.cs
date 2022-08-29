using UnityEngine;
using UnityEngine.InputSystem;

namespace Sunnfolk_Complete.Scripts.Player
{
    public class Input : MonoBehaviour
    {

        public Vector2 moveVector;
    
    
        // Start is called before the first frame update
        private void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {
            moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) 
                           + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        
            moveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) 
                           + (Keyboard.current.wKey.isPressed ? 1f : 0f);
        }
    }
}
