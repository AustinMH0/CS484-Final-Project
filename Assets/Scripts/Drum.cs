using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour {

    [SerializeField] Material litMaterial;
    [HideInInspector] public bool wasHit = false;
    Material unlitMaterial;
    Renderer r;

    void Start() {
        r = GetComponent<Renderer>();
        unlitMaterial = r.material;
    }


    void OnTriggerEnter(Collider other) {
        // play sound
        wasHit = true;
    }

    public void SetLitStatus(bool lit) {
        r.material = lit ? litMaterial : unlitMaterial;
    }
}
