using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public float delay = 1f; // 延迟时间，单位为秒

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
