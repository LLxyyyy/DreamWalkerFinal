using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public float healAmount = 10f; // ÿ�λ�Ѫ����
    public float healInterval = 1f; // ��Ѫ���ʱ��
    private float lastHealTime = 0f; // �ϴλ�Ѫʱ��

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
