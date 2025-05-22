using System.Collections;
using UnityEngine;

public class NavPlayer : MonoBehaviour
{
    public enum EState { Ready, Moving }

    //private NavWaypoint[] path = null;
    private EState curState = EState.Ready;
    private float moveSpeed = 1f;

    public void SetPath(NavWaypoint[] _path)
    {
        if (curState == EState.Moving) return;
        if (_path == null || _path.Length <= 1) return;
        //path = _path;
        StartCoroutine(MovingCoroutine(_path));
    }

    private IEnumerator MovingCoroutine(NavWaypoint[] _path)
    {
        //NavWaypoint startWaypoint = _path[0];
        //NavWaypoint endWaypoint = _path[1]; //Çò°¥¸®´Ï±ñ ¾È¿¡ ³Ö´Â°É·Î 
        int startIdx = 0; //startWaypoint

        transform.position = _path[startIdx].Position;
        _path[startIdx].SetState(NavWaypoint.Estate.Pass);

        curState = EState.Moving;

        int endIdx = 1; //endWaypointIndex
        float t = 0f;
        while (endIdx < _path.Length)//Å»Ãâ¹® 
        {
            t += Time.deltaTime * moveSpeed;
            transform.position =
                Vector3.Lerp(
                    _path[startIdx].Position,
                    _path[endIdx].Position,
                    t);

            if(t > 1f)
            {
                _path[endIdx].SetState(NavWaypoint.Estate.Pass);

                ++startIdx; //==startIdx = endIdx;
                ++endIdx;
                t = 0f;
            }
            yield return null;
        }
        curState = EState.Ready;
    }
    public bool IsMoving()
    {
        return curState == EState.Moving;
    }
}
