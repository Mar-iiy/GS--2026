using UnityEngine;
using System.Collections;

public class ObjSpawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private float wait;
    [SerializeField] private GameObject objPrefab;


    private Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(Fall());
    }

    void Update()
    {

    }

    IEnumerator Fall()
    {
        while (true)
        {
            Instantiate(objPrefab, new Vector3(Random.Range(-4, 4), Random.Range(-1, 3), 15), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
    }
}
