using UnityEngine;

public class TrashTask : MonoBehaviour
{
    public GameObject[] trash; 
    public Transform spawnPoint;

    private GameObject currentObject;

    private int spawnCount = 0;
    [SerializeField] public int maxSpawns;

    void Update()
    {
        if (spawnCount >= maxSpawns)
            return;

        if (currentObject == null)
        {
            SpawnRandomPrefab();
        }
    }

    public void SpawnRandomPrefab()
    {
        if (changeToComputer.computerUsed)
        {

            if (spawnCount >= maxSpawns)
                return;

            int randomIndex = Random.Range(0, trash.Length);

            currentObject = Instantiate(
                trash[randomIndex],
                spawnPoint.position,
                spawnPoint.rotation
            );

            spawnCount++;
        }      
    }
}
