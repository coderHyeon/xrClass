//using UnityEngine;//����Ƽ����namespace�� ����

using NUnit.Framework;
using System.Diagnostics;

public class AutoRotate : UnityEngine.MonoBehaviour
{
    [UnityEngine.Range(-100f, 100f)]
    public float rotateSpeed = 10f;

    //������ �߰��ϱ�
    public AutoRotate()//���̶�Ű�� �߰��� �Ǹ� new ���Ǹ鼭 ����Ƽ�� �����(�츮�� new �ϴ°� �ƴ�) ���۳�Ʈ�� �پ��־�� �۵�
    {
        UnityEngine.Debug.Log("AutoRotate Constructor Call!!");//����Ƽâ ����
    }
    // �����ڴ� ����Ƽ���� �߱��ϴ� ����� �ƴ� 
    // �ʱ�ȭ Ÿ�̹��� ���� ������ ���� �����ӿ�ũ�� �̹� ����� ���� 
    // ���ӿ��� ����� �������� �ִ� ĳ���͸� �ҷ��� �����ڴ� ���ӿ��� ĳ���Ͱ� ������ �ٽ� new�ؾ��ϴµ� ���� ó�� ���� ��ġ�� �ٲ� �� �ֵ��� �̹������� Init() �� ���
    // �ʱ�ȭ Ÿ�̹��� ���������
    // ������ �ʱ�ȭ 
    // Framework
    // Init - Input - Update - Render - Destroy
    // Lazy Initialization
    // Life - Cycle : �ᱹ �츮�� �������� ����Ƽ�� �ص״ٰ� �ص� ���ӿ��� ���̴� ����� �ٸ� �� �� �����ϱ�?
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() //�����ڶ� ���  ������ �� �ʱ�ȭ��ų��? ������ ȣ���� ���� �ɰ���/
    {
        UnityEngine.Debug.Log("start");
    }

    // Framerate 
    // 60FPS (Frame Per Seconds)

    // Update is called once per [frame] fram�� �������� ���ظ� �ؾ���
    void Update()
    { //�����Ӹ��� ������Ѿ��ϴ°� �ִ°� 
        //UnityEngine.Debug.Log("Update");

        transform.Rotate(UnityEngine.Vector3.up, rotateSpeed * UnityEngine.Time.deltaTime);

    }
}
