using UnityEngine;

/// <summary>
/// Particle effect manager for visual feedback
/// </summary>
public class ParticleEffectManager : MonoBehaviour
{
    public static ParticleEffectManager Instance { get; private set; }

    [SerializeField] private ParticleSystem collisionParticles;
    [SerializeField] private ParticleSystem goalReachedParticles;
    [SerializeField] private ParticleSystem slidingParticles;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCollisionEffect(Vector3 position)
    {
        if (collisionParticles != null)
        {
            ParticleSystem ps = Instantiate(collisionParticles, position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }
    }

    public void PlayGoalEffect(Vector3 position)
    {
        if (goalReachedParticles != null)
        {
            ParticleSystem ps = Instantiate(goalReachedParticles, position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }
    }

    public void PlaySlidingEffect(Vector3 position, Vector3 velocity)
    {
        if (slidingParticles != null && velocity.magnitude > 1f)
        {
            ParticleSystem ps = Instantiate(slidingParticles, position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, 1f);
        }
    }
}
