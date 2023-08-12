using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DotSpawnScript : MonoBehaviour
{
    public GameObject dot;
    public GameObject paddle;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(1);
    }

    // create a target dot somewhere on the circle
    public void Spawn(int direction)
    {
        target = Instantiate(dot, paddle.transform.position, transform.rotation);
        target.transform.RotateAround(Vector3.zero, Vector3.back, UnityEngine.Random.Range(65, 180) * direction);
    }

    // delete a target dot
    public void Delete()
    {
        Destroy(target);
    }
}
