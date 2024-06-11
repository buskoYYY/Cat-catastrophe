using UnityEngine;

public class PlayerHitter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hittable")
        {
            if (!hit.gameObject.CompareTag("Hitted"))
            {
                hit.gameObject.tag = "Hitted";

                Rigidbody rigidbody = hit.gameObject.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(_explosionForce, transform.position + Vector3.down, _explosionRadius);
            }
        }
        if (hit.gameObject.tag == "Hitted")
        {
            Rigidbody rigidbody = hit.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddExplosionForce(_explosionForce, transform.position + Vector3.down, _explosionRadius);
        }
    }
}
