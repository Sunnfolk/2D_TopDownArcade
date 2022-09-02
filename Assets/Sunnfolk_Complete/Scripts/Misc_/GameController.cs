using Sunnfolk_Complete.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class GameController : MonoBehaviour
    {
        public  int enemyNumber;
        public int scoreNumber;
        public int goal;

        private PlayerController _controller;
        
        private void Start()
        {
            enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
            GameObject.Find("Player").TryGetComponent(out PlayerController playerController);
            
            _controller = playerController;
            scoreNumber = _controller.score;
        }

        // Update is called once per frame
        public void Update()
        {
            scoreNumber = _controller.score;
            
            if (scoreNumber >= goal && enemyNumber <= 0)
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }
}