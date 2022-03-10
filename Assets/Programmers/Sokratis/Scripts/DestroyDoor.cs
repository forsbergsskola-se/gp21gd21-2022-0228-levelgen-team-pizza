using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
}
