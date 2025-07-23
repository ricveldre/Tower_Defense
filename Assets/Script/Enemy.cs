using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private EnemyData _enemyData;
    [SerializeField]
    private string _targetTag = "Tower";
    private Transform _target;
    private Health _targetHealth;
    private bool _isRunning;
    private void OnEnable()
    {
        _isRunning = false;
        GetTarget();
    }
    private void GetTarget()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(_targetTag);
        if (targetObject != null)
        {
            _target = targetObject.transform;
            _targetHealth = targetObject.GetComponent<Health>();
            _isRunning = true;
            _animator.Play(_enemyData.runAnimationName);
        }
    }
    private void Update()
    {
        if (_isRunning)
        {
            transform.LookAt(_target);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _enemyData.runSpeed = Time.deltaTime);
            if (Vector3.Distance(transform.position, _target.position) <= _enemyData.attackRange) 
            {
                _isRunning = false;
                StartCoroutine(Attack());
            }
        }
    }
    private IEnumerator Attack()
    {
        while (_target != null && _targetHealth.CurrentHealth > 0)
        {
            _animator.Play(_enemyData.attackAnimationName, 0, 0f);
            yield return new WaitForSeconds(_enemyData.attackDuration);
            _targetHealth.TakeDamage(_enemyData.attackDamage);
            yield return new WaitForSeconds(_enemyData.attackWaitTime);
        }
    }
    private void Osable()
    {
        _isRunning = false;
        _target = null;
        _targetHealth = null;
        StopAllCoroutines();
    }
}
