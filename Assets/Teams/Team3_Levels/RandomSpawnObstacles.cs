using System.Collections;
using System.Collections.Generic;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RandomSpawnObstacles : MonoBehaviour
{
    public GameObject terrain;
    public GameObject[] obstacleInventory;
    [Tooltip("from -x, to x; from -y to y; from -z to z")]
    public Vector3 spawnRange;
    public uint obstaclesInLevelCount;
    public bool drawDebugLines;
    public bool spawnObstaclesOnStart;

    void Start()
    {
        if (spawnObstaclesOnStart)
            SpawnObstacles(obstaclesInLevelCount);
    }

    public void SpawnObstacles(uint count) // Count : How many obstacles to spawn
    {

        int index = 0;
        Vector3 spawnPosition;
        for (int i = 0; i < count; ++i)
        {
            GameObject obstacleToSpawn = obstacleInventory[index];

            float obstacleHeight = obstacleToSpawn.GetComponent<Renderer>().bounds.size.y;
            float obstacleWidth = obstacleToSpawn.GetComponent<Renderer>().bounds.size.x;

            index = Random.Range(0, obstacleInventory.Length);

            spawnPosition = new Vector3(Random.Range(-spawnRange.x/2 + obstacleWidth, spawnRange.x/2 - obstacleWidth),
                                               terrain.transform.position.y + (obstacleHeight/2),
                                               Random.Range(-spawnRange.z/2 + obstacleWidth, spawnRange.z/2 - obstacleWidth));


            Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(RandomSpawnObstacles))]
public class RandomSpawnObstaclesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RandomSpawnObstacles myScript = (RandomSpawnObstacles)target;

        if (GUILayout.Button("Spawn Obstacles"))
        {
            myScript.SpawnObstacles(myScript.obstaclesInLevelCount);

        }
    }
}
#endif
