using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Activator : MonoBehaviour
{   // Для двух групп объектов указываем массив для двух групп
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;

    // указываем вторую кнопку
    public Activator button;

    // и материалы: нормальный и прозрачный
    public Material normal;
    public Material transparent;

    public void OnTriggerEnter(Collider other)
    {   // если при условие что кнопки коснулся обычный куб или игрок, то
        if (other.CompareTag("Cube") || other.CompareTag("Player")) 
        {   // пишем цикл foreach для каждого объекта в первой группе
            foreach (GameObject first in firstGroup) 
            {
                // материал  у нас будет нормальным
                first.GetComponent<Renderer>().material = normal;
                //  через блоки нельзя будет проходить
                first.GetComponent<Collider>().isTrigger = false;
            }

            foreach (GameObject second in secondGroup)
            {
                second.GetComponent<Renderer>().material = transparent;
                // позволяет нам ходить через блоки
                second.GetComponent<Collider>().isTrigger = true;
            }
            // материал самой кнопки будет прозрачным
            GetComponent<Renderer>().material = transparent;
            // а материал второй кнопки будет нормальным 
            button.GetComponent<Renderer>().material = normal; // для того чтобы они менялись по очереди
        }
    }



}
