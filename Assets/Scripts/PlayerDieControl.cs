using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void DieReturnClick()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
        Debug.Log("Diereturn");

    }
    public void DieContinueClick()
    {
        SceneManager.LoadScene("Summer");
        Time.timeScale = 1;
        Debug.Log("Diecontinue");

    }
}
