using Sunnfolk_Complete.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class UIManager : MonoBehaviour
    {

        public PlayerController player;

        public TMP_Text scoreText;
    
    
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
        }
    }
}
