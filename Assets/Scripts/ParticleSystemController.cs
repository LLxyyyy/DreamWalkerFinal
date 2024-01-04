using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public float delay = 1f; // �ӳ�ʱ�䣬��λΪ��

    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        Invoke("StopParticleSystem", delay);
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();

    }
}
