//using UnityEngine;//유니티엔진namespace가 있음

using NUnit.Framework;
using System.Diagnostics;

public class AutoRotate : UnityEngine.MonoBehaviour
{
    [UnityEngine.Range(-100f, 100f)]
    public float rotateSpeed = 10f;

    //생성자 추가하기
    public AutoRotate()//하이라키에 추가가 되면 new 가되면서 유니티에 실행됨(우리가 new 하는거 아님) 컴퍼넌트에 붙어있어야 작동
    {
        UnityEngine.Debug.Log("AutoRotate Constructor Call!!");//유니티창 띄우기
    }
    // 생성자는 유니티에서 추구하는 방법은 아님 
    // 초기화 타이밍을 게임 내에서 폼과 프레임워크가 이미 양식이 있음 
    // 게임에서 목숨이 여러개가 있는 캐릭터를 할려면 생성자는 게임에서 캐릭터가 죽으면 다시 new해야하는데 차라리 처음 시작 위치로 바뀔 수 있도록 이미정해진 Init() 를 사용
    // 초기화 타이밍을 정해줘야함
    // 게으른 초기화 
    // Framework
    // Init - Input - Update - Render - Destroy
    // Lazy Initialization
    // Life - Cycle : 결국 우리가 만들어야함 유니티가 해뒀다고 해도 게임에서 쓰이는 방법이 다를 수 도 있으니까?
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() //생성자랑 비슷  시작할 때 초기화시킬때? 생성자 호출은 언제 될건지/
    {
        UnityEngine.Debug.Log("start");
    }

    // Framerate 
    // 60FPS (Frame Per Seconds)

    // Update is called once per [frame] fram이 무엇일지 이해를 해야함
    void Update()
    { //프레임마다 변경시켜야하는걸 넣는곳 
        //UnityEngine.Debug.Log("Update");

        transform.Rotate(UnityEngine.Vector3.up, rotateSpeed * UnityEngine.Time.deltaTime);

    }
}
