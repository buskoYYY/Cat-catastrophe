using UnityEngine;
using UnityEngine.AI;

public class AIPlayer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private  NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;

    [Header("Settings")]
    [SerializeField] private float radius = 10f;

    public void PlayAiPlayerAnimation() // ����� ����������� 5-�� �������
    {
        _animator.Play("walk"); 
    }

    private Vector3 RandomNavMeshLocation(float radius) // ������������ ������ 3 ������� ����� ����� ������ �������� ����
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
        _navMeshAgent.destination = RandomNavMeshLocation(radius);
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance < 1.5f)
        {
            ChangeDest();
        }
    }
}
