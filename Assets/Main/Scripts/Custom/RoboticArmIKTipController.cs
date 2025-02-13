using UnityEngine;

public class RoboticArmIKTipController : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    private bool isInRange = false;
    private Vector3 sleepPosition;
    private Quaternion sleepRotation;
    private readonly float moveThreshold = 0.005f;

    private void Start()
    {
        sleepPosition = tip.position;
        sleepRotation = tip.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isInRange)
        {
            Sleep();
        }
        else
        {
            Track();
        }
    }

    private void Move(Vector3 targetPosition)
    {
        Vector3 tipToTarget = targetPosition - tip.position;
        if (Vector3.SqrMagnitude(tipToTarget) > moveThreshold)
        {
            tip.position += moveSpeed * Time.deltaTime * tipToTarget.normalized;
        }
    }

    private void Rotate(Quaternion lookRotation)
    {
        tip.rotation = Quaternion.Slerp(tip.rotation, lookRotation, Time.deltaTime * 2f);
    }

    private void Track()
    {
        Move(target.position);
        //Rotate(Quaternion.LookRotation((lookTarget.position - tip.position).normalized));
        Rotate(target.rotation);
    }

    private void Sleep()
    {
        Move(sleepPosition);
        Rotate(sleepRotation);
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
