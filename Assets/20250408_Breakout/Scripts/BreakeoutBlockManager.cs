using System.Collections.Generic;
using UnityEngine;

public class BreakeoutBlockManager : MonoBehaviour
{
    private readonly Color[] colors =
    {
        Color.red,Color.yellow, Color.green, Color.blue
    };

    [SerializeField] private GameObject blockPrefab = null;
    [SerializeField] private int rowCnt = 9;
    [SerializeField] private int colCnt = 6;
    [SerializeField] private float rowOffset = 1f;
    [SerializeField] private float colOffset = 1f;

    private List<BreakoutBlock> blockList = new List<BreakoutBlock>();
    //const 기본자료형만됨 
    public void Init()
    {
        BuildBlocks();
    }
    private void Start()
    {
        BuildBlocks();
    }
    private void BuildBlocks()
    {
        //블럭시작위치 구하기

        Vector2 blockSize = new Vector2(
            //메모리에 올라기전의 정보를 가져옴 // 스케일 로컬스케일을 가져와야함
            blockPrefab.transform.localScale.x ,                                            
            blockPrefab.transform.localScale.y
        );
        Vector3 blockSizeHalf = blockSize * 0.5f;
        Vector2 startPos = Vector2.zero;
        Vector2 blockizePadding = Vector2.zero;

        blockizePadding.x = blockSize.x + rowOffset;
        blockizePadding.y = blockSize.y + colOffset;

        startPos.x = (((blockSize.x + rowOffset) * colCnt) * 0.5f * -1f ) + (rowOffset * 0.5f);
        startPos.y = ((blockizePadding.y * rowCnt) * 0.5f + (colOffset * 0.5f)) ;

        int colorIdx = 0;//반복문변수는 위로올리는게 나은데 이유는 계속 쓸거기 때문
        for(int row = 0; row <rowCnt; ++row)
        {
            //colorIdx = row / 2;
            //정밀도가 더높자료형으로 바뀌는것 - 자료형의 승격
            colorIdx = Mathf.Min((int)(row * 0.5f), colors.Length - 1);

            for(int col = 0; col < colCnt; ++col)
            {
                //Instantiate원본정보의 기본으로 만들어줌
                GameObject blockGo = Instantiate(blockPrefab);
                blockGo.name = "Block_" +"r"+row + "_" + "c" + col;
                blockGo.transform.SetParent(transform);
                //위치를 부모를 기준으로 했기때문에 월드 포지션이아닌 로컬포지션으로 해줌
                blockGo.transform.localPosition = new Vector3(
                    startPos.x + (blockizePadding.x * col) + blockSizeHalf.x,
                    startPos.y - (blockizePadding.y * row) - blockSizeHalf.y,
                    0f);
                blockGo.GetComponent<MeshRenderer>().material.color = colors[colorIdx];

                blockList.Add(blockGo.GetComponent<BreakoutBlock>());
            }
        }
    }
    public void ResetBlocks()
    {
        foreach(BreakoutBlock block in blockList)
        {
            if (!block.IsActive)
                block.SetActive(true);
        }
    }

    public int GetTotalCout()
    {
        return blockList.Count;

    }
    public int GetActiveCount()
    {
        int cnt = 0;
        foreach (BreakoutBlock block in blockList)
            if (block.IsActive) ++cnt;
        return cnt;
    }

    public int GetDestroyCout()
    {
        int cnt =0;
        for (int i = 0; i < blockList.Count; ++i)
            if (!blockList[i].IsActive) ++cnt;
        return cnt;
    }

}
