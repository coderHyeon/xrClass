using UnityEngine;

public class BreakGameManager : MonoBehaviour
{
    private enum EGameState { Ready,Play, GameOver}

    //1. 인스펙터에서 끌어오기 BreakoutPaddle만 끌고 올수 있음
    [SerializeField] private BreakoutPaddle paddle = null;
    [SerializeField] private BreakeoutBlockManager blockMng = null;  
    [SerializeField] private BreakoutBlockCounter blockCounter = null;
    [SerializeField] private BreakoutScore score = null; 
    [SerializeField] private BreakoutGameOver gameOver = null;

    //2. 태그
    private BreakoutBall ball = null;

    private EGameState gameState = EGameState.Ready;

    private Vector3 paddleStartPos = Vector3.zero;



    private void Awake()
    {
        //1. 게임오브젝트 태그 ball로 찾기
        //절대 사용하면 안됨 - 문자열을 하이어라키에서 전부 비교함
        GameObject ballGo = GameObject.Find("Ball");
        //2. 태그를 통해서 찾아서 빠른건 맞지만 사실 하면안됨  문자열을 절대 비교해서 찾는 행위는 게임에서 하면 안됨
        ballGo = GameObject.FindGameObjectWithTag("Ball");
        //1,2 방법들은 
        // 객체지향도 깨짐
        // 이미태그가 만들어있는지 확인하기용으로만 사용하기
        ball = ballGo.GetComponent<BreakoutBall>();
    }

    private void Start()
    {

        paddleStartPos = paddle.transform.position;
        ball.GameOverCallback = GameOverCallback;
        ball.AddCollisionBlockCallback(() =>
        {
            UpdateBlockCounter();
            UpdateScore();
        });

        blockMng.Init();

        gameOver.SetRestartButtonListener(() =>
        {
            GameReset();
        });

        GameReset();
    }

    private void Update()
    {
        if (gameState == EGameState.GameOver) return;

        float h = Input.GetAxis("Horizontal");
        paddle.MovingHorizontal(h);

        if (gameState == EGameState.Ready && Input.GetKeyDown(KeyCode.Space))
        {
            //normalized 무조건 45도로 나감
            Vector3 moveDir = paddle.MoveDirection.normalized + Vector3.up;
            ball.SetMoveDirection(moveDir);
            ball.transform.SetParent(null);
            gameState = EGameState.Play;
        }
        if (Input.GetKeyDown(KeyCode.R))
            GameReset();

    }
    // 블럭 복구 3번째 방법 블럭 on off로 해결 -> 갯수가 바뀐다면 어떻게 할건지
    private void GameReset()
    {
        //패들의 위치 크기에따라 바뀔수 있게짜야하지만 너무 길어서
        paddle.transform.position = paddleStartPos; // 초기화
        Vector3 ballPos = paddle.transform.position;
        ballPos.y += 1f;
        //ball.transform.position = ballPos;
        ball.transform.position = ballPos;
        ball.transform.SetParent(paddle.transform);
        ball.ResetMoveDirection();

        blockMng.ResetBlocks();

        UpdateBlockCounter();
        score.ResetScore();
        // 오브젝트를 접근하는것도 해당 스크립트에서 만드는게 나음//gameOver.SetActive(false)
        gameOver.gameObject.SetActive(false);
        

        gameState = EGameState.Ready;
    }

    public void GameOverCallback()
    {
        gameState = EGameState.GameOver;
        //Debug.Log("Game over");
        //Debug.Break();
        gameOver.gameObject.SetActive(true);
    }

    private void UpdateBlockCounter()
    {
        blockCounter.SetBlockCount(
                blockMng.GetActiveCount(),
                blockMng.GetTotalCout()
                );

    }
    private void UpdateScore()
    {
        score.SetScore(blockMng.GetDestroyCout() * 10);
    }

}
