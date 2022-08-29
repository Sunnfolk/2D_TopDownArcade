using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sunnfolk_Complete.Scripts.Misc_
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToStart()
        {
            SceneManager.LoadScene(0);
        }
    }
}