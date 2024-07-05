using UnityEngine;

public class PlayerHitter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _particlesPref;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private ScoreManager _scoreManager;

    [Header("Settings")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _scorePerHit;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.gameObject.GetComponent<Rigidbody>();
        if (hit.gameObject.tag == "Hittable")
        {

            if (!hit.gameObject.CompareTag("Hitted"))
            {
                hit.gameObject.tag = "Hitted";
                rigidbody.isKinematic = false;
                iTween.PunchScale(_scoreText, new Vector3(1.5f, 1.5f, 1.5f), 1.5f);
                ApplyForce(rigidbody, _explosionForce, _explosionRadius);
                ParticlesHitEffect(hit);
                _scoreManager.ModifyScore(_scorePerHit);
                _scoreManager.SaveScore();
                AudioPlayer.instance.PlayHittingClip();
            }
        }
        if (hit.gameObject.tag == "Hitted")
        {
            ApplyForce(rigidbody, _explosionForce, _explosionRadius);
        }
    }

    private void ApplyForce(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position + Vector3.down, explosionRadius);
    }

    private void ParticlesHitEffect(ControllerColliderHit hit)
    {
        int random = Random.Range(0, _particlesPref.Length);
        var particles = Instantiate(_particlesPref[random], hit.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(particles,2);
    }
}
