using UnityEngine;

public class PlayerHitter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Particles _particles;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private TweenEffects _tweenEffects;

    [Header("Settings")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _scorePerHit;
    [SerializeField] private int _currencyPerHit;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.gameObject.GetComponent<Rigidbody>();
        if (hit.gameObject.tag == "Hittable")
        {

            if (!hit.gameObject.CompareTag("Hitted"))
            {
                hit.gameObject.tag = "Hitted";
                rigidbody.isKinematic = false;
                ApplyForce(rigidbody, _explosionForce, _explosionRadius);
                HitEffect(hit);
            }
        }
        if (hit.gameObject.tag == "Hitted")
        {
            ApplyForce(rigidbody, _explosionForce, _explosionRadius);
        }
    }

    private void HitEffect(ControllerColliderHit hit)
    {
        CoinsHitEffect();
        _particles.ParticlesHitEffect(hit);
        AudioPlayer.instance.PlayHittingClip();
        _tweenEffects.TweenScaleEffect();
    }

    private void CoinsHitEffect()
    {
        _scoreManager.ModifyScore(_scorePerHit);
        _currencySystem.AddCurrency(_currencyPerHit);
        _scoreManager.SaveScore();
    }

    private void ApplyForce(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position + Vector3.down, explosionRadius);
    }
}
