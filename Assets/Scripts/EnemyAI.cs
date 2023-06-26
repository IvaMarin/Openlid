using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Chasing,
        Returning
    }

    private State _state;

    private Vector3 _startingPosition;
    private Vector3 _roamPosition;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _roamingRange;

    [SerializeField]
    private float _chasingRange;

    [SerializeField]
    private float _stopChaseDistance;

    private NavMeshAgent _navMeshAgent;
    private NavMeshPath _navMeshPath;

    private AudioSource _audioSource;

    private NavMeshHit _hit;

    private void Awake()
    {
        _state = State.Roaming;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _navMeshPath = new NavMeshPath();
    }

    private void Start()
    {
        _startingPosition = transform.position;
        _roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Roaming:
                if (_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                }

                Debug.DrawLine(transform.position, _hit.position, Color.magenta);
                _navMeshAgent.SetDestination(_roamPosition);


                float reachedPositionDistance = 10f;
                if (Vector3.Distance(transform.position, _roamPosition) < reachedPositionDistance)
                {
                    _roamPosition = GetRoamingPosition();
                }

                FindTarget();
                break;
            case State.Chasing:
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                _navMeshAgent.SetDestination(_player.position);

                if (Vector3.Distance(transform.position, _player.position) > _stopChaseDistance)
                {
                    _state = State.Returning;
                }
                break;
            case State.Returning:
                if (_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                }
                _navMeshAgent.SetDestination(_startingPosition);
                break;
        }
    }

    private Vector3 GetRoamingPosition()
    {
        
        while (true)
        {
            NavMesh.SamplePosition(_startingPosition + Random.insideUnitSphere * _roamingRange,
            out NavMeshHit navMeshHit, _roamingRange, NavMesh.AllAreas);

            if (_navMeshAgent.CalculatePath(navMeshHit.position, _navMeshPath) && 
                _navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                _hit = navMeshHit;
                return navMeshHit.position;
            }

        }
    }
    private void FindTarget()
    {
        if (Vector3.Distance(transform.position, _player.position) < _chasingRange)
        {
            _state = State.Chasing;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_startingPosition, _roamingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chasingRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _stopChaseDistance);
    }
}
