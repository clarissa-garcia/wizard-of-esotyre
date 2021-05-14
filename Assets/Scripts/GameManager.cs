using System.Collections;
using UnityEngine;

/// <summary>
/// Where the player is at in terms of progression in the world
/// </summary>
public enum GameState
{
    TOWER,
    TOWN,
    FOREST,
    CAVE
}

public delegate void OnStateChangeHandler();
public delegate void OnBridgeRepairHandler();

public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    public  static GameManager Instance = null;
    public event OnStateChangeHandler OnStateChange;
    public static event OnBridgeRepairHandler OnBridgeRepair;
    public GameState gameState { get; private set; }

    [Header("Interaction Settings")]
    public bool repair = false;
    public bool destroy = false;
    public bool jumpBoost = false;

    private static bool bridgeRepaired = false; 

    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

    


    public bool BridgeRepaired(){
        return bridgeRepaired;
    }

    public void FixBridge(){
        bridgeRepaired = true; 
        Debug.Log("Bridge Repaired");
        OnBridgeRepair();
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.Instance = null; 
    }

}
