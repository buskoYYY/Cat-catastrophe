using UnityEngine;

public class Particles : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _particlesPref;
    [SerializeField] private ParticleSystem _jumpEffectPrefab;

    [Header("Settings")]
    [SerializeField] private float _livetime;
    [SerializeField] private Vector3 _possiTionOffset;

    public void ParticlesHitEffect(ControllerColliderHit hit)
    {
        int random = Random.Range(0, _particlesPref.Length);
        var particles = Instantiate(_particlesPref[random], hit.transform.position + _possiTionOffset, Quaternion.identity);
        Destroy(particles, _livetime);
    }

    public void PlayJumpParticles(Vector3 spawnPos)
    {
        Instantiate(_jumpEffectPrefab,spawnPos, Quaternion.identity);
    }
}
