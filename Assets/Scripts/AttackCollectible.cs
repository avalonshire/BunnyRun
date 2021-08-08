using UnityEngine;

public class AttackCollectible : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
