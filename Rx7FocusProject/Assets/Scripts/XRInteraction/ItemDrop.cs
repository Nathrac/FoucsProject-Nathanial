using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] string objectTag;
    [SerializeField] AudioSource dropSFX;


    private void OnCollisionEnter(Collision collision) //if object falls and collides with ground, play drop sound effect.
    {
        if (collision.gameObject.tag == objectTag)
        {
            dropSFX.Play();
        }
    }
}
