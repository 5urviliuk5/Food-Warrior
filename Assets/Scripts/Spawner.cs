using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject fruitPrefab;
    public List<Wave> waves;

    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach (var fruit in wave.items)
            {
                var prefab = fruit.isBomb ? bombPrefab : fruitPrefab;
                var go = Instantiate(prefab);
                go.transform.position = new Vector3 (fruit.x, -5f, 0);
                var rb2d = go.GetComponent<Rigidbody2D>();
                rb2d.velocity = fruit.velocity;
                await new WaitForSeconds(fruit.delay);
            }
            await new WaitForSeconds(3f);
        }
    }
}