using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // добавляем новую библиотеку для перехода на след. уровень

public class Player : MonoBehaviour
{
    // [SerializeField] - то что в квадратных скобочках, позволяет нам что-либо задать в инспекторе(в юнити), в любое время!
    [SerializeField] KeyCode KeyOne;  // клавиша один
    [SerializeField] KeyCode KeyTwo;  // клавиша два
    [SerializeField] Vector3 moveDirection;

    private void FixedUpdate()
    {   // если у нас нажата первая клавиша
        if (Input.GetKey(KeyOne)) 
        {
            // то к скорости нашего куба мы будем прибавлять вектор 3 направление
            GetComponent<Rigidbody>().velocity += moveDirection; 
        }

        if (Input.GetKey(KeyTwo))
        {                                   // -= это направление, для передвижения куба в противоположную сторону
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Input.GetKey(KeyCode.R)) 
        {               // для рестарта уровня
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Q))
        {                                                                 // + 1 для перехода на след. уровень 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        // если наш объект является игроком, а объект с которым он столкнулся является финишом, то
        if (this.CompareTag("Player") && other.CompareTag("Finish")) 
        {
            // данная команда отвечает за загрузку след. сцены
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       
    }

}
