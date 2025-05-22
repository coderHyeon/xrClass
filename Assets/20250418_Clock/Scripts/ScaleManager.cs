
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ScaleManager : MonoBehaviour
{
    private GameObject cubePrefab = null;
    private GameObject cubeParent = null;
    private Component[] managerCube = null;
    private GameObject handPrefabMin = null;
    private GameObject handPrefabSc = null;
    private GameObject handPrefabHr = null;
    private double totalSeconds = 0;
    private double secondes = 0;
    private double minunts = 0;
    private double hours = 0;
    private MeshRenderer[] mrs = null;
    //?
    private readonly Color[] colors = {
        Color.red, Color.green, Color.blue
    };
    private Object[] allCube = null;

    void Awake()
    {
        cubePrefab =
                Resources.Load<GameObject>("Prefabs\\P_Cube");
        cubeParent = GameObject.Find("ScaleManager");

        totalSeconds = System.DateTime.Now.TimeOfDay.TotalSeconds;
        minunts = (totalSeconds / 60) % 60;
        secondes = totalSeconds % 60;
        hours = totalSeconds / 3600;
        Init("minInit");
        Init("scInit");
        Init("hrInit");
    }

    void Start()
    {
        handPrefabMin = GameObject.Find("minInit");
        handPrefabSc = GameObject.Find("scInit");
        handPrefabHr = GameObject.Find("hrInit");

        //매니저 + Init
        //프리팹연습    
        //cubePrefab =
        //        Resources.Load<GameObject>("Prefab\\P_Cube");
        //GameObject realLoadGo = Instantiate(cubePrefab);
        //GameObject parent = GameObject.Find("IndexManager");
        //realLoadGo.transform.SetParent(parent.transform);

        BuildBlocks();
        StyleByHand();

    }

    // Update is called once per frame
    void Update()
    {
        totalSeconds = System.DateTime.Now.TimeOfDay.TotalSeconds;
        minunts = (int)(totalSeconds / 60) % 60;
        secondes = (int)totalSeconds % 60;
        hours = (int)totalSeconds / 3600;
        ClockHand(minunts, handPrefabMin);
        ClockHand(secondes, handPrefabSc);
        ClockHand(hours, handPrefabHr);
        //Init().gameObject.ClockHand(secondes, GameObject handGo);
    }
    //private int timeReturn(double totalSeconds)
    //{
    //    reutnr int 
    //}

    private void BuildBlocks()
    {
        float theta30 = 0.523599f;
        float distance = 10f;

        for (int i = 1; i < 13; i++)
        {
            Vector3 blockSize = new Vector3(
                cubePrefab.transform.localScale.x,
                cubePrefab.transform.localScale.y,
                cubePrefab.transform.localScale.z
                );
            //int blockW= cubePrefab.transform.localScale.x * 0.1;

            float plusTheta = theta30 * i;

            Vector3 potionPos = new Vector3(Mathf.Cos(plusTheta), Mathf.Sin(plusTheta), 0f) * distance;

            //GameObject cubeGo =
            //   Instantiate(
            //       cubePrefab,
            //       potionPos,
            //       Quaternion.identity,
            //       transform.parent
            //       );
            ////////////////////////////// 여기에 큐브사이즈 변화 가능?

            // 큐브 사이즈 변화
            Vector3 cubeTr = i % 3 == 0 ? blockSize * 2 : blockSize;
            // 큐브생성
            GameObject cubeGo = Instantiate(cubePrefab);
            cubeGo.transform.localScale = cubeTr;
            cubeGo.transform.localPosition = potionPos;
            cubeGo.transform.LookAt(Vector3.zero);
            cubeGo.name = cubePrefab.name + i;
            cubeGo.transform.SetParent(cubeParent.transform);
        }
    }
    private GameObject Init(string st)
    {
        GameObject handGo = Instantiate(cubePrefab);
        handGo.transform.localScale = new Vector3(
               cubePrefab.transform.localScale.x / 10,
               cubePrefab.transform.localScale.y / 10,
               cubePrefab.transform.localScale.z * 8);
        handGo.name = st;
        handGo.transform.SetParent(cubeParent.transform);
        mrs = handGo.GetComponentsInChildren<MeshRenderer>();
        Vector3 rHandGo = handGo.transform.localScale;
        if (mrs[0].name == "hrInit")
        {
            Debug.Log(mrs[0].name);
            mrs[1].material.color = Color.red;
        }
        if (mrs[0].name == "scInit")
        {
            Debug.Log(mrs[0].name);
            mrs[1].material.color = Color.blue;
        }
        if (mrs[0].name == "scInit")
        {
            Debug.Log("scInit : "+mrs[0].name);
            mrs[1].material.color = Color.yellow;
        }
        // StyleByHand();
        return handGo;
    }

    private void StyleByHand()
    {
        managerCube = GetComponentsInChildren<Component>();
        allCube = managerCube;
        Debug.Log("llCube.Length" + allCube.Length);
        int cnt = allCube.Length;
        Debug.Log("cnt" + cnt);
        //for (int i = 0; i < cnt; i++)
        //{


        Vector3 trHandGo = transform.position;
        //if (allCube[i].name == "scInit")
        //{
        //    Debug.Log("StyleByHand handGo.name2" + allCube[i].name);

        //    allCube[i + 1].GetComponent<MeshRenderer>().material.color = Color.red;
        //}
        //else if (allCube[i + 1].name == "minInit")
        //{
        //    trHandGo.x = cubePrefab.transform.localScale.x * 2;
        //    allCube[i + 1].GetComponent<MeshRenderer>().material.color = Color.gray;
        //}
        //else if (allCube[i + 1].name == "hrInit")
        //{
        //    trHandGo.x = cubePrefab.transform.localScale.y / 10;

        //    allCube[i+1].GetComponent<MeshRenderer>().material.color = Color.blue;
        //}

        //}

        //handPrefabMin = GameObject.Find("minInit");
        //handPrefabSc = GameObject.Find("scInit");
        //handPrefabHr = GameObject.Find("hrInit");
        //mrs = GetComponentsInChildren<MeshRenderer>();
        //handPrefabSc.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        //if (handPrefabMin.name == "scInit")
        //{
        //    Debug.Log("이프문 통과 확인" + handPrefabMin.name);
        //    // Debug.Log("StyleByHand handGo.name2" + handPrefabMin.GetComponentInChildren<Component>);

        //    mrs[1].GetComponent<MeshRenderer>().material.color = Color.red;
        //}
        //else if (handPrefabSc.name == "minInit")
        //{
        //    trHandGo.x = cubePrefab.transform.localScale.x * 2;
        //    handPrefabSc.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        //}
        //else if (handPrefabHr.name == "hrInit")
        //{
        //    trHandGo.x = cubePrefab.transform.localScale.y / 10;

        //    handPrefabHr.GetComponent<MeshRenderer>().material.color = Color.blue;
        //}
    }// 스타일 따로하기 실패
    private void ClockHand(double _timeHand, GameObject handGo)
    {

        //if(timeHand)
        float theta6 = -0.10472f;
        float theta60 = -1.0472f;
        float theta90 = 1.5708f;

        //Debug.Log("thetaFirst" + theta6);
        int timeHandInt = (int)_timeHand;
        //Debug.Log(handGo.name);
        //if (timeHand == null!) return;

        if (handGo.name == "hrInit")
        {
            theta6 = theta6 * 10f - (theta90);

        }


        Vector3 handGoTr = transform.position;
        handGoTr.y = (cubePrefab.transform.position.y) * 0.5f;
        float distance = handGoTr.y;
        //Debug.Log("thetaSecond" + theta6);
        if (timeHandInt % 1 == 0)
        {
            float thethPluse = theta6 * timeHandInt + theta90;
            // Debug.Log(" handGo " + (int)_timeHand);
            //float td = thethPluse *= Mathf.Rad2Deg;
            float positionPos = Mathf.Atan2(Mathf.Cos(theta6), Mathf.Sign(theta6));
            Vector3 positionPosVec = new Vector3(Mathf.Cos(thethPluse), Mathf.Sin(thethPluse), 0f) * (-4f);

            //GameObject minHandGo = Instantiate(cubePrefab);
            //minHandGo.transform.localScale = new Vector3(
            //  cubePrefab.transform.localScale.x / 10,
            //  cubePrefab.transform.localScale.y / 10,
            //  cubePrefab.transform.localScale.z * 8); //따로 빼기

            Vector3 moveDir = handGo.transform.position - (-positionPosVec);
            moveDir.Normalize();
            moveDir.z = 0f;
            handGo.transform.position = -positionPosVec + (moveDir * Time.deltaTime);
            handGo.transform.SetParent(cubeParent.transform);
            handGo.transform.LookAt(Vector3.zero);
            //  Destroy(frontHand);
        }

    }
}

