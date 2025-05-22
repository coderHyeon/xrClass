using UnityEngine;

[ExecuteInEditMode]// ������ �Ƚ��ѵ� update�� ���ư�
public class NavWaypoint : MonoBehaviour
{
    public enum Estate { Normal, Check, Pass }

    private readonly Color[] stateColors =
    {
       new Color(1f, 1f, 1f, 0.5f),
       new Color(1f, 1f, 0f, 0.5f),
       new Color(1f, 0f, 0f, 0.5f)
    };

    [SerializeField] private NavWaypoint[] nextWaypoints = null;

    private Estate curState = Estate.Normal;
    private MeshRenderer[] mrs = null;

    public NavWaypoint[] NextWaypoints
    {
        get { return nextWaypoints; }
    }
    public Vector3 Position
    {
        get { return transform.position; }
    }

    private void Awake()
    {
        mrs = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (nextWaypoints == null || nextWaypoints.Length == 0) return;

        for(int i = 0; i< nextWaypoints.Length; ++i)
        {
            Debug.DrawLine(Position, nextWaypoints[i].Position, Color.red);
        }
    }

    public void SetState(Estate _state)
    {
        curState = _state;

        mrs[0].material.color = stateColors[(int)curState];
        mrs[1].material.color = stateColors[(int)curState];
    }

    //!!!!!!!!!!!���ľ���
    public void SetStateNormal()
    {
        SetState(Estate.Normal);
    }
}
