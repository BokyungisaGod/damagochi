using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // heart, red, yellow, green, purple 등의 프리팹 배열

    public float spawnInterval = 1.5f; // 스폰 간격 조절을 위한 변수
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        // 랜덤하게 오브젝트를 선택
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        // 오브젝트를 생성하고 하늘에서 떨어지도록 설정
        GameObject spawnedObject = Instantiate(selectedPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        // Rigidbody2D 컴포넌트가 있다면 속도를 설정하여 떨어지도록 함
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, -2f); // 하늘에서 아래로 이동
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        // 스폰 위치를 랜덤하게 반환
        float randomX = Random.Range(-5f, 5f); // X 좌표를 -5에서 5 사이에서 랜덤으로 선택
        float ySpawnPosition = 7f; // Y 좌표를 상단에서 스폰하도록 설정
        return new Vector2(randomX, ySpawnPosition);
    }
}
