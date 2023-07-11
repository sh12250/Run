using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public int height;


    // Start is called before the first frame update
    void Start()
    {
        height = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnFood(GameObject platform)
    {
        int randIdx = Random.Range(0, foodPrefabs.Length);

        GameObject food = Instantiate(foodPrefabs[randIdx], platform.transform.position + new Vector3(0, height, -2), platform.transform.rotation, platform.transform);
    }
}
