using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumManager : MonoBehaviour {
    public Drum[] drums;
    public int[] pattern;

    int nPattern = 0;

    void Update() {
        if (drums[pattern[nPattern]].wasHit) {
            drums[pattern[nPattern]].SetLitStatus(false);
            nPattern += 1;
            if (nPattern >= pattern.Length) {
                nPattern = 0;
            }
            drums[pattern[nPattern]].wasHit = false;
        }
        drums[pattern[nPattern]].SetLitStatus(true);
    }
}
