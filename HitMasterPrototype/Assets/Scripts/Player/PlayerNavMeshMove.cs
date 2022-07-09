using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshMove : MonoBehaviour
{    
    public int playerPlatform;
    [SerializeField] float _distenceToPoint;

    Animator _animator;
    NavMeshAgent _agent;
    public NavMeshAgent agent { get { return _agent = _agent ?? GetComponent<NavMeshAgent>(); } }
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public void MovePlayer(Vector3 pos)
    {       
        agent.SetDestination(pos);
    }
    private void Update()
    {
        if (agent.hasPath)
        {
            
            if (agent.remainingDistance < _distenceToPoint)
            {
                GameManager.Instence.OnPosition(playerPlatform);
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pos"))
        {
            playerPlatform++;
        }
        if(other.CompareTag("Finish"))
        {
            GameManager.Instence.Restart();
        }
    }
}
