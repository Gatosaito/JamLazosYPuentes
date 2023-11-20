using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islas : MonoBehaviour
{

    #region variables
    [SerializeField] private float frequency;
    [SerializeField] private float magnitude;
    [SerializeField] private Vector3 offset_Y;
    private Vector3 desirePosition;
    #endregion

    private void Start()
    {
        desirePosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = (desirePosition + transform.up * (Mathf.Sin(Time.time * frequency) * magnitude) + offset_Y);
    }

}
