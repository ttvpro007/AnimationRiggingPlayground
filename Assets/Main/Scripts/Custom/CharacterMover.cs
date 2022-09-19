using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private float threshold = 0.01f;
    private bool shouldMove = false;

    public float velocity => target && shouldMove ? speed : 0f;

    private void Update()
    {
        if (!target) return;

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 vToTarget = target.position - transform.position;
        shouldMove = Vector3.SqrMagnitude(vToTarget) > threshold;
        if (shouldMove)
        {
            transform.position += speed * Time.deltaTime * vToTarget.normalized;
        }
    }
}