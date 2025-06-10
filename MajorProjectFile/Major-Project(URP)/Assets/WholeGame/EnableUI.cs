using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        Invoke(nameof(CanvasEnable), 7f);
        
    }

    private void CanvasEnable()
    {
         canvas.SetActive(true);
    }
}
