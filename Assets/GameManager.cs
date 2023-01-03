using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

   bool           GameHasEnded = false;
   public float   RestartDelay = 1f;


   public void EndGame() {

        if (GameHasEnded == false) {

            GameHasEnded = true;
            Invoke("Restart", RestartDelay);
        }
   }
    

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
