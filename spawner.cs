using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fallingBlockPrefab;
    Vector2 screenHalfSize;
    public Vector2 secondsToMinMaxSpawn;
    float nextSpawnTime;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            //GameObject gameObject =  fallingBlockPrefab.transform.localScale(Random.Range(-.5f, 1));
            float secondsToNextSpawn = Mathf.Lerp(secondsToMinMaxSpawn.y, secondsToMinMaxSpawn.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsToNextSpawn;
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize/2);
            GameObject newObject =(GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler
                (Vector3.forward * spawnAngle));
            newObject.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
