using UnityEngine;
using static VMGameState;

public class NMGameMng : MonoBehaviour
{
    private enum EGameState { Ready, Play, GameOver }
    private EGameState gameState = EGameState.Ready;

    private NMEnemySpawnMng enemyMng = null;
    void Start()
    {
        enemyMng.Init();
    }

 
    void Update()
    {
        if (gameState == EGameState.GameOver) return;
    }
}
