using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private Level[] _levels;

    [Header("Settings")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _initialTimeToChangeDest;
    [SerializeField] private int _startAILevel = 1;
    [SerializeField] private float _radius = 10f;
    private float _timeToChangeDest;


    private void Start()
    {
        _timeToChangeDest = _initialTimeToChangeDest;
        _animator.Play("walk");
    }
    private void Update()
    {
         _timeToChangeDest -= Time.deltaTime;
        int roundTime = (int)_timeToChangeDest;
        if (roundTime < 0)
        {
            _timeToChangeDest = _initialTimeToChangeDest;
        }
        Debug.Log(_timeToChangeDest);

        if ( roundTime == 0 || _navMeshAgent.remainingDistance < 1.5f)
        {
            ChangeDest();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Hittable")
        {
            rigidbody.isKinematic = false;
            ApplyForce(rigidbody, _explosionForce, _explosionRadius);
        }
        if (collision.gameObject.tag == "Hitted")
        {
            ApplyForce(rigidbody, _explosionForce, _explosionRadius);
        }
    }
    private void ApplyForce(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position + Vector3.down, explosionRadius, .2f);
    }

    private Vector3 RandomNavMeshLocation(float radius) // возвращается вектор 3 который будет будет местом движения кота
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void ChangeDest()
    {
        _navMeshAgent.destination = RandomNavMeshLocation(_radius);
    }

}