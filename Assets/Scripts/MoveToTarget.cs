using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private float moveSpeed;
    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!target) return;

        Move();
    }

    private void Move()
    {
        Vector3 tipToTarget = target.position - tip.position;
        if (Vector3.SqrMagnitude(tipToTarget) > 0.2f)
        {
            tip.position += moveSpeed * Time.deltaTime * tipToTarget.normalized;
        }
    }

    private void Rotate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform.Find("ModelRoot").Find("EyeTracker");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }
}
