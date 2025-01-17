using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Character"))
        {
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
