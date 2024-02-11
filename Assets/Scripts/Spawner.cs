using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public List<GameObject> fruitPrefabs;
    public List<Wave> waves;

    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach (var fruit in wave.items)
            {
                await new WaitForSeconds(fruit.delay);

                var prefab = fruit.isBomb ? bombPrefab : fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
                var go = Instantiate(prefab);
                go.transform.position = new Vector3 (fruit.x, -5f, 0);

                var rb2d = go.GetComponent<Rigidbody2D>();
                rb2d.velocity = fruit.velocity;
            }

            await new WaitForSeconds(3f);
        }
    }
}