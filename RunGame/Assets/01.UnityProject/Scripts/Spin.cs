using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;

    private Vector3 foodRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinFood();
    }
    public void SpinFood()
    {
        foodRotation.y = spinSpeed * Time.deltaTime;
        transform.Rotate(foodRotation);
    }
}
