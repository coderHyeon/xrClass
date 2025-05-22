using UnityEngine;

public class BGTileMap : MonoBehaviour
{
    [SerializeField] private Sprite[] tileSet = null;
    [SerializeField] private GameObject tilePrefab = null;
    private Vector2 tileSize = new Vector2(0.32f,0.32f);
        //readonly랑 const랑 차이는 readonly는 동적할당 하는게 가능 cosnt는 불가능

    private int[] tileMap =
    {
        4,5,5,5,5,6,
        7,3,3,3,3,8,
        7,3,3,3,3,8,
        7,3,3,3,3,8,
        7,3,3,3,3,8,
        0,1,1,1,1,2,
    };

    private const int rowCnt = 6;
    private const int colCnt = 6;

    private void Start()
    {
        float tileWidth = 32f;
        float tileHeight = 32f;
        tileSize.x = tileWidth / tileSet[0].pixelsPerUnit;
        tileSize.y = tileHeight / 100f; // 위랑 같은거임?
        BuildTileMap();
    }
    private void BuildTileMap()
    {
        float totalCol = colCnt * tileSize.x;
        float totalRow = rowCnt * tileSize.y;
        Vector2 tileSizeHalf = tileSize * 0.5f;
        float startPosX = -(totalCol * 0.5f) + tileSizeHalf.x;
        float startPosY = (totalRow * 0.5f) - tileSizeHalf.y;

        for(int row = 0; row <rowCnt; ++row)
        {
            for(int col =0; col<colCnt; ++col)
            {
                Vector3 pos = new Vector3(
                    startPosX +(col*tileSize.x),
                    startPosY +(row*tileSize.y),
                    0f);
                GameObject tileGo = Instantiate(
                    tilePrefab,
                    pos,
                    Quaternion.identity,
                    transform
                    );
                SpriteRenderer sr =
                    tileGo.GetComponent<SpriteRenderer>();
                int tileIdx = tileMap[(row*colCnt) +col];
                sr.sprite = tileSet[tileIdx];
            }
        }
    }
}
