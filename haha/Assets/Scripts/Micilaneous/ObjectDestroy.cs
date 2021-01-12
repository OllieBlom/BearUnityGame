using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{

    public float duration = 1;

    private float _initial_Time;
    // Start is called before the first frame update
    void Start()
    {
        _initial_Time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _initial_Time > duration)
        {
            Destroy(gameObject);
        }
    }
}
