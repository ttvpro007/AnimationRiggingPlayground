using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform moveTarget;
    [SerializeField] private Transform lookTarget;

    private bool isInRange = false;

    // Update is called once per frame
    private void Update()
    {
        if (!isInRange) return;

        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 tipToTarget = moveTarget.position - tip.position;
        if (Vector3.SqrMagnitude(tipToTarget) > 0.2f)
        {
            tip.position += moveSpeed * Time.deltaTime * tipToTarget.normalized;
        }
    }

    private void Rotate()
    {
        Quaternion lookRotation = Quaternion.LookRotation((lookTarget.position - tip.position).normalized);
        tip.rotation = Quaternion.Slerp(tip.rotation, lookRotation, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }
}
