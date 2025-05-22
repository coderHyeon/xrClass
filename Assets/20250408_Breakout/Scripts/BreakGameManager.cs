using UnityEngine;

public class BreakGameManager : MonoBehaviour
{
    private enum EGameState { Ready,Play, GameOver}

    //1. �ν����Ϳ��� ������� BreakoutPaddle�� ���� �ü� ����
    [SerializeField] private BreakoutPaddle paddle = null;
    [SerializeField] private BreakeoutBlockManager blockMng = null;  
    [SerializeField] private BreakoutBlockCounter blockCounter = null;
    [SerializeField] private BreakoutScore score = null; 
    [SerializeField] private BreakoutGameOver gameOver = null;

    //2. �±�
    private BreakoutBall ball = null;

    private EGameState gameState = EGameState.Ready;

    private Vector3 paddleStartPos = Vector3.zero;



    private void Awake()
    {
        //1. ���ӿ�����Ʈ �±� ball�� ã��
        //���� ����ϸ� �ȵ� - ���ڿ��� ���̾��Ű���� ���� ����
        GameObject ballGo = GameObject.Find("Ball");
        //2. �±׸� ���ؼ� ã�Ƽ� ������ ������ ��� �ϸ�ȵ�  ���ڿ��� ���� ���ؼ� ã�� ������ ���ӿ��� �ϸ� �ȵ�
        ballGo = GameObject.FindGameObjectWithTag("Ball");
        //1,2 ������� 
        // ��ü���⵵ ����
        // �̹��±װ� ������ִ��� Ȯ���ϱ�����θ� ����ϱ�
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
            //normalized ������ 45���� ����
            Vector3 moveDir = paddle.MoveDirection.normalized + Vector3.up;
            ball.SetMoveDirection(moveDir);
            ball.transform.SetParent(null);
            gameState = EGameState.Play;
        }
        if (Input.GetKeyDown(KeyCode.R))
            GameReset();

    }
    // �� ���� 3��° ��� �� on off�� �ذ� -> ������ �ٲ�ٸ� ��� �Ұ���
    private void GameReset()
    {
        //�е��� ��ġ ũ�⿡���� �ٲ�� �ְ�¥�������� �ʹ� ��
        paddle.transform.position = paddleStartPos; // �ʱ�ȭ
        Vector3 ballPos = paddle.transform.position;
        ballPos.y += 1f;
        //ball.transform.position = ballPos;
        ball.transform.position = ballPos;
        ball.transform.SetParent(paddle.transform);
        ball.ResetMoveDirection();

        blockMng.ResetBlocks();

        UpdateBlockCounter();
        score.ResetScore();
        // ������Ʈ�� �����ϴ°͵� �ش� ��ũ��Ʈ���� ����°� ����//gameOver.SetActive(false)
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
