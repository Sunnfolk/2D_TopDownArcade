using Sunnfolk_Complete.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class GameController : MonoBehaviour
    {
        public  int enemyNumber;
        public int scoreNumber;

        public int Goal;
        
        private void Awake()
        {
            enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
            GameObject.Find("Player").TryGetComponent(out PlayerController playerController);
            scoreNumber = playerController.score;
        }

        // Update is called once per frame
        public void Update()
        {
            if (scoreNumber >= Goal && enemyNumber <= 0)
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }
}
