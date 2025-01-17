using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
}
