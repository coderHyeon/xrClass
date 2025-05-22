using UnityEngine;

public class SurvivorsGameManager : MonoBehaviour
{
    [SerializeField] private SurvivorsPlayer player = null;
    [SerializeField] private SurvivorsMonsterSpawner spawner = null;
    [SerializeField] private SurvivorsHpBar playerHpBar = null;


    private void Update()
    {
        // ���� ������� ��ã�ƺ��� 
        // �򶧸� ���� ã���� ��
        // 

        SurvivorsMonster nearMonster =
            spawner.GetNearMonster(player.transform.position);
        if(nearMonster != null)
        {
            //�÷��̾����� ���� ����� Ÿ���� �������� �˷��ֱ�
            player.SetTarget(nearMonster);
        }
        DisplayPlayerHp();
    }
    private void DisplayPlayerHp()
    {
        //���� �������� ������ �𸣴ϱ� ������Ʈ���� ��� �÷��̾��� ���¸� �˾ƾ���
        playerHpBar.SetHP(player.MaxHp, player.HP);
        playerHpBar.UpdatePosition(player.transform.position);

    }

}
