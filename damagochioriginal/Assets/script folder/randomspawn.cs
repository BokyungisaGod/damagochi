using System.Collections;
using UnityEngine;

public class randomspawn : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 떨어질 물체들의 배열

    void Start()
    {
        StartCoroutine(SpawnRandomObjects());
    }

    IEnumerator SpawnRandomObjects()
    {
        while (true)
        {
            int randomCount = Random.Range(1, 4); // 랜덤한 개수의 물체 생성 (1에서 3까지의 랜덤한 수)

            for (int i = 0; i < randomCount; i++)
            {
                SpawnObject();
                yield return new WaitForSeconds(1.0f); // 물체 생성 간격을 조절할 수 있습니다. 여기서 1.0f를 조정하여 떨어지는 속도를 조절할 수 있습니다.
            }

            yield return new WaitForSeconds(Random.Range(1f, 3f)); // 다음 물체 생성을 위한 대기 시간 설정
        }
    }

    void SpawnObject()
    {
        // 랜덤한 위치에서 랜덤한 물체 스폰
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], GetRandomSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // 스폰 위치를 랜덤으로 설정하는 함수
        float spawnX = Random.Range(-5f, 5f); // 원하는 x 범위 설정
        float spawnY = 7f; // 위에서 떨어지므로 y는 일정한 값으로 설정
        float spawnZ = 0f; // z 축은 2D 게임이므로 0으로 설정

        return new Vector3(spawnX, spawnY, spawnZ);
    }
}
