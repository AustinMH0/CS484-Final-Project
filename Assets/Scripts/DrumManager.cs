using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumManager : MonoBehaviour {

    [Serializable]
    public class Pattern {
        public string name;
        public int[] drumOrder;
    }

    [SerializeField] TMPro.TextMeshProUGUI patternText;
    [SerializeField] InputActionAsset inputActions;

    public Drum[] drums;
    public Pattern[] patterns;

    int i = 0;
    int nPattern = 0;

    InputAction patternForward;
    InputAction patternBack;

    void Start() {
        patternBack = inputActions["XRI LeftHand Interaction/Activate"];
        patternForward = inputActions["XRI RightHand Interaction/Activate"];
    }

    void Update() {
        if (GetDrum().wasHit) {
            GetDrum().SetLitStatus(false);
            i += 1;
            if (i >= patterns[nPattern].drumOrder.Length) {
                i = 0;
            }
            GetDrum().wasHit = false;
        }
        GetDrum().SetLitStatus(true);

        if (patternForward.triggered) {
            nPattern += 1;
            i = 0;
        }
        if (patternBack.triggered) {
            nPattern -= 1;
            i = 0;
        }
        if (nPattern < 0) {
            nPattern = patterns.Length - 1;
        }
        if (nPattern >= patterns.Length) {
            nPattern += 1;
        }
        patternText.text = patterns[nPattern].name;
    }

    Drum GetDrum() {
        return drums[patterns[nPattern].drumOrder[i]];
    }
}
