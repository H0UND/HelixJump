using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public Transform FinishPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform CylinderRoot;
    public float ExtracylinderScale = 2f;
    public GameObject FirstPlatformPrafab;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        var random = new Random(levelIndex);

        int platformCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);

        for (int i = 0; i < platformCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrafab = i == 0 ? FirstPlatformPrafab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrafab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
            {
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
            }
        }
        FinishPlatformPrefab.localPosition = CalculatePlatformPosition(platformCount);

        CylinderRoot.localScale = new Vector3(1, platformCount * DistanceBetweenPlatforms + ExtracylinderScale, 1);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float maxExclusive)
    {
        float number = (float)random.NextDouble();
        return Mathf.Lerp(min, maxExclusive, number);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}