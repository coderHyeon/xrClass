using UnityEngine;

public class SurvivorsWeaponSpawner : MonoBehaviour
{
    private GameObject[] weaponPrefabs = null;
    private int spawnCnt = 20;
    private void Awake()
    {
        weaponPrefabs = Resources.LoadAll < GameObject>("Prefabs\\Weapons") ;
    }
    private void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for(int i = 0; i < spawnCnt; ++i)
        {
            int rndIdx = Random.Range(0, weaponPrefabs.Length);
            GameObject weaponGo =
               Instantiate(weaponPrefabs[rndIdx]);

            Vector2 rndPos = Random.insideUnitCircle;
            Vector3 pos = new Vector3(rndPos.x, rndPos.y, 0f) * 50f;
            weaponGo.transform.position = pos;
            weaponGo.transform.localScale = Vector3.one * 3f;
        }
    }
}
