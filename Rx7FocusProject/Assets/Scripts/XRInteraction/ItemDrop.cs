using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] string objectTag;
    [SerializeField] AudioSource dropSFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            dropSFX.Play();
        }
    }
}
