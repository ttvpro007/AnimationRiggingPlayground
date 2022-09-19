using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float moveSpeed, rotateSpeed;
    private Vector3 currentPosition;
    private Vector3 currentEulerAngles;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = target.transform.position;
        currentEulerAngles = target.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;

        if (Input.anyKey)
        {
            ProcessInputGetKey();
            target.transform.position = currentPosition;
            target.transform.eulerAngles = currentEulerAngles;
        }
    }

    void ProcessInputGetKey()
    {
        // move
        if (Input.GetKey(KeyCode.A)) currentPosition.x -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) currentPosition.x += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) currentPosition.y -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) currentPosition.y += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) currentPosition.z -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) currentPosition.z += moveSpeed * Time.deltaTime;

        // rotate
        if (Input.GetKey(KeyCode.K)) currentEulerAngles.x -= rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.I)) currentEulerAngles.x += rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.J)) currentEulerAngles.y -= rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.L)) currentEulerAngles.y += rotateSpeed * Time.deltaTime;
    }
}
