using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] OmokManager mng = null;
    enum EColor { NONE = 0, BLACK = 1, WHITE = 2 }
    EColor color;
    public bool myTurn = true;
    public int lastRow;
    public int lastCol;
    
    private void Update()
    {
        if (myTurn)
        {
            Play();
        }
    }
    public void SetColor(int n)
    {
        color = (EColor)n;
    }
    public int GetColor()
    {
        return (int)color;
    }
    public void Play()
    {
        // 제대로 된 곳에 버튼을 누르면 턴을 종료
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hitInfo))
            {
                string split = hitInfo.transform.parent.name;
                MeshRenderer rend = GetComponent<MeshRenderer>();
                
                Transform stone = hitInfo.transform.parent.Find("Stone");
                if(stone != null)
                {
                    string[] split_data = split.Split('x');
                    lastRow = int.Parse(split_data[0]) - 1; 
                    lastCol = int.Parse(split_data[1]) - 1;
                    Renderer ren = stone.gameObject.GetComponent<MeshRenderer>();
                    Material mat = ren.material;
                    // color는 플레이어에 따라 
                    if (mng.gamePlate[lastRow][lastCol] == 0)
                    {
                        mat.SetColor("_BaseColor", new Color((int)color -1, (int)color - 1, (int)color - 1, 1));
                        myTurn = false;
                    }
                    else
                    {
                        Debug.Log("둔곳Player");
                    }

                }
            }
            Debug.Log("ok");
        }
    }
}
