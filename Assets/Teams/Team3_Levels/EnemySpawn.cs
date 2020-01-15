using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public int AmountofEn;
    public Vector3 SpawnArea;
    public List<GameObject> ArrayOfEn;
    void Start()
    {
        ArrayOfEn = new List<GameObject>();
        for (int i = 0; i < AmountofEn; i++)
        {
            Vector3 Spawn;
            Spawn.x = Random.Range(-SpawnArea.x, SpawnArea.x);
            Spawn.z = Random.Range(-SpawnArea.z, SpawnArea.z);
            GameObject objectEn = Instantiate(Enemy, new Vector3(Spawn.x, 0, Spawn.z), Quaternion.identity);
            ArrayOfEn.Insert(i,objectEn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
