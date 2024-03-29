using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // ��������� ����� ���������� ��� �������� �� ����. �������

public class Player : MonoBehaviour
{
    // [SerializeField] - �� ��� � ���������� ���������, ��������� ��� ���-���� ������ � ����������(� �����), � ����� �����!
    [SerializeField] KeyCode KeyOne;  // ������� ����
    [SerializeField] KeyCode KeyTwo;  // ������� ���
    [SerializeField] Vector3 moveDirection;

    private void FixedUpdate()
    {   // ���� � ��� ������ ������ �������
        if (Input.GetKey(KeyOne)) 
        {
            // �� � �������� ������ ���� �� ����� ���������� ������ 3 �����������
            GetComponent<Rigidbody>().velocity += moveDirection; 
        }

        if (Input.GetKey(KeyTwo))
        {                                   // -= ��� �����������, ��� ������������ ���� � ��������������� �������
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Input.GetKey(KeyCode.R)) 
        {               // ��� �������� ������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Q))
        {                                                                 // + 1 ��� �������� �� ����. ������� 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        // ���� ��� ������ �������� �������, � ������ � ������� �� ���������� �������� �������, ��
        if (this.CompareTag("Player") && other.CompareTag("Finish")) 
        {
            // ������ ������� �������� �� �������� ����. �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       
    }

}
