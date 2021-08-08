using UnityEngine;

public class CollectGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().isGemCollected = true;
        Destroy(gameObject);
    }
}
