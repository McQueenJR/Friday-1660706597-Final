using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public bool battleStarted = false;

    void Awake()
    {
        Instance = this;
    }

    public void StartBattle()
    {
        battleStarted = true;

        GridManager.Instance.HideGrid();

        Debug.Log("Battle Start");
    }
}