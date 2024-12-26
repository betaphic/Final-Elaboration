using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLifeSystem playerLifeSystem = collision.GetComponent<PlayerLifeSystem>();
            if (playerLifeSystem != null)
            {
                playerLifeSystem.PlayerDied();
            }
            else
            {
                Debug.LogWarning("Player does not have a PlayerLifeSystem component!");
            }
        }
    }
}
