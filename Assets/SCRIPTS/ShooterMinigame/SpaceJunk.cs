using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceJunk : MonoBehaviour
{ 
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    void Update()
    {
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "limit")
        {
            Destroy(this.gameObject);
            showPoints.batidas++;
        }

        if(other.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
            showPoints.pontos++;
        }

        if(!changeToComputer.computerIsOn)
        {
            Destroy(this.gameObject);
        }
    }
}
