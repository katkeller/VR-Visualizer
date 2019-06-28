using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private float respawnDelay = 5.0f;

    [SerializeField]
    private AudioClip destroy, respawn;

    private bool isDestroyed = false;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        if (!isDestroyed)
        {
            audioSource.PlayOneShot(destroy, 0.1f);
            meshRenderer.enabled = false;
            isDestroyed = true;
            StartCoroutine(DelayRespawn());
        }
    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        audioSource.PlayOneShot(respawn, 0.1f);
        meshRenderer.enabled = true;
        isDestroyed = false;
    }
}
