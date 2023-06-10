using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private const float Depth = 10;
    private const float Height = 30;
    private const float LeftLengthRange = -15;
    private const float RightLengthRange = 15;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var cube = Instantiate(_cube);
            cube.transform.position = new Vector3(Random.Range(LeftLengthRange, RightLengthRange), Height, Depth);
        }
    }
}