using UnityEngine;

public class FadeOutParent : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    private ParticleSystem[] particleSystems;
    private float currentAlpha = 1f;

    private void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    private void Update()
    {
        currentAlpha -= fadeSpeed * Time.deltaTime;

        foreach (ParticleSystem ps in particleSystems)
        {
            var mainModule = ps.main;
            var startColor = mainModule.startColor;
            var color = startColor.color;
            color.a = currentAlpha;
            startColor.color = color;
        }

        if (currentAlpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
