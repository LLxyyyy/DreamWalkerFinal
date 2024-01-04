using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public float healAmount = 10f; // 每次回血的量
    public float healInterval = 1f; // 回血间隔时间
    private float lastHealTime = 0f; // 上次回血时间

    void OnTriggerStay(Collider other)
    {
        print("heal");
        if (other.tag == "Player")
        {
            if (Time.time - lastHealTime > healInterval)
            {
                PlayerAttackController playerHealth = other.GetComponent<PlayerAttackController>();
                if (playerHealth != null)
                {
                    playerHealth.Heal(healAmount);
                    lastHealTime = Time.time;
                }
            }
        }
    }
}
