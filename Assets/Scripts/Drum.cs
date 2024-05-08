using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour {

    [SerializeField] Material litMaterial;
    [HideInInspector] public bool wasHit = false;
    Material unlitMaterial;
    Renderer r;

    private AudioSource audioSource;

    void Start() {
        r = GetComponent<Renderer>();
        unlitMaterial = r.material;
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other) {
        // play sound
        audioSource.Play();
        Debug.Log(audioSource.clip.name);
        wasHit = true;
    }

    public void SetLitStatus(bool lit) {
        r.material = lit ? litMaterial : unlitMaterial;
    }
}
