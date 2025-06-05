using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class OmokManager : MonoBehaviour
{
    int maxPlate = 15;
    // Network
    [SerializeField] Player[] player = new Player[2];
    public int[][] gamePlate = new int[15][];
    int lastRow = 0;
    int lastCol = 0;
    int curTurn = 0;
    bool gameEnd = false;
    bool updateOk = true;

    private void Awake()
    {
        player[0].SetColor(1);
        player[0].myTurn = true;
        player[1].SetColor(2);
        player[1].myTurn = false;
        for(int i = 0; i < maxPlate; ++i)
        {
            gamePlate[i] = new int[15];
        }
    }
    private void Update()
    {
        if (gameEnd)
        {
            Debug.Log("Update GameEnd");
            return;
        }
        else
        {
            if (!player[curTurn].myTurn)
            {
                
                UpdatePlate();
                VictoryCheck();
                NextTurn();
            }
        }
        
    }

    private void NextTurn()
    {
        curTurn = 1 - curTurn;
        player[curTurn].myTurn = true;
        //Debug.Log("NextTurn");
    }
    private void UpdatePlate()
    {
        lastRow = player[curTurn].lastRow;
        lastCol = player[curTurn].lastCol;
        gamePlate[lastRow][lastCol] = player[curTurn].GetColor();
    }
    private void VictoryCheck()
    {
        // 최근에 둔 돌을 기준으로 방향 검사
        // 오른쪽, 위쪽, 대각선2개 (반대는 -)
        int[][] direction = new int[4][]
        {
            new int[] { 0, 1 }, // 오른쪽 왼쪽
            new int[] { 1, 0 }, // 위 아래
            new int[] { 1, 1 }, // 대각선/
            new int[] { 1, -1 } // 대각선 \
        };
        // 네방향 검사
        for(int i = 0; i < 4; ++i)
        {
            int count = 1;
            bool chk1 = true;
            bool chk2 = true;

            // 오목이 되는 조건 : 자신을 포함하여 5개가 있는지 검사
            for(int j = 1; j < 5; ++j)
            {
                int l1 = lastRow - direction[i][0] * j;
                int l2 = lastCol - direction[i][1] * j;
                // 범위를 벗어나지않으면서  
                if(!(l1 >= maxPlate || l2 >= maxPlate || l1 < 0 || l2 < 0) && chk1)
                {
                    //Debug.Log(l1 + "," + l2);
                    // 자신의 색이라면 count 증가
                    if (gamePlate[l1][l2] == player[curTurn].GetColor())
                    {
                      //  Debug.Log("Count++");
                        ++count;
                    }
                    else // 다른 색이거나 비워져있었다면 검사 x
                    {
                        chk1 = false;
                    }
                }
                int r1 = lastRow + direction[i][0] * j;
                int r2 = lastCol + direction[i][1] * j;
                if(!(r1 >= maxPlate || r2 >= maxPlate || r1 < 0 || r2 < 0) && chk2)
                {
                    //Debug.Log(r1 + "," + r2);
                    if (gamePlate[r1][r2] == player[curTurn].GetColor())
                    {
                      //  Debug.Log("Count++");
                        ++count;
                    }
                    else
                    {
                        chk2 = false;
                    }
                }
            }
            if(count == 5) // 정확히 5라면 승리
            {
                GameEnd();
                // 게임 종료처리
                break;
            }
            Debug.Log("i : " + i + "Count : " + count);
        }
    }
    private void GameEnd()
    {
        Debug.Log("승리");
        int winnerNum = curTurn + 1;
        Debug.Log(winnerNum + "'s Win.");
        gameEnd = true;
    }
}
