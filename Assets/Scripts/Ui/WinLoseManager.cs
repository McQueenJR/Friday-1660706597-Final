using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public GameObject winText;

    public GameObject loseText;

    private bool gameEnded = false;

    void Start()
    {
        winText.SetActive(false);

        loseText.SetActive(false);
    }

    void Update()
    {
        if (!BattleManager.Instance.battleStarted)
            return;
        if (gameEnded) return;

        CheckWinLose();
    }

    void CheckWinLose()
    {
        GameObject[] redTeam =
            GameObject.FindGameObjectsWithTag("RedPlayer");

        GameObject[] blueTeam =
            GameObject.FindGameObjectsWithTag("BluePlayer");

        if (redTeam.Length == 0)
        {
            Lose();
        }

        if (blueTeam.Length == 0)
        {
            Win();
        }
    }

    void Win()
    {
        gameEnded = true;

        winText.SetActive(true);

        Debug.Log("YOU WIN");
    }

    void Lose()
    {
        gameEnded = true;

        loseText.SetActive(true);

        Debug.Log("YOU LOSE");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}