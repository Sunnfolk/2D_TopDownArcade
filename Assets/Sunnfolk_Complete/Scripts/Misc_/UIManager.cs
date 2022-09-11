using Sunnfolk_Complete.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class UIManager : MonoBehaviour
    {
        public PlayerController player;

        public TMP_Text scoreText;
        public TMP_Text timerText;
        public float timer = 100f;
        
        // Start is called before the first frame update
        public void Start()
        {
            GameObject.Find("Player").TryGetComponent(out PlayerController playerController);
            player = playerController;
        }

        // Update is called once per frame
        private void Update()
        {
            scoreText.text = $"Score {player.score}";
            timerText.text = Mathf.Round(timer).ToString();

            if (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }
}