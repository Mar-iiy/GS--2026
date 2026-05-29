using UnityEngine;
using System.Collections;


public class bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
