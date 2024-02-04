using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits; // Array of fruit prefabs

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    void Spawn()
    {
        int numberOfFruits = Random.Range(1, 6); // Get a random number between 1 and 5

        for (int i = 0; i < numberOfFruits; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-5, 5), -5);
            int randomIndex = Random.Range(0, fruits.Length); // Get a random index between 0 and fruits.Length-1
            Instantiate(fruits[randomIndex], pos, Quaternion.identity); // Spawn the fruit at the random position
        }
    }
}