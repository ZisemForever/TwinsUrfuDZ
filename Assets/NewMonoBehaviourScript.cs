using UnityEngine;

public class RigidbodyMod : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ������ - ����� ���������� ����������
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.mass = 1.0f;
            _rb.linearDamping = 0;
            _rb.angularDamping = 0.05f;
            _rb.useGravity = true;
            _rb.isKinematic = false;
        }

        // 1 - ��������/��������� ����������
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _rb.useGravity = !_rb.useGravity;
            Debug.Log("Gravity: " + _rb.useGravity);
        }

        // 2 - ����������� kinematic �����
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _rb.isKinematic = !_rb.isKinematic;
            Debug.Log("Kinematic: " + _rb.isKinematic);
        }

        // 3 - ��������� �����
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _rb.mass *= 2f;
            Debug.Log("Mass: " + _rb.mass);
        }

        // 4 - �������� �������
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }

        // 5 - ��������� ��������� ����
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            Vector3 randomForce = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(5f, 15f),
                Random.Range(-10f, 10f)
            );
            _rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}