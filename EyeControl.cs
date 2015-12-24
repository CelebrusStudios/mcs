using UnityEngine;
using System.Collections;
using MORPH3D;

public class EyeControl : MonoBehaviour
{
    M3DCharacterManager m;
    System.Random r;

    // Blink time
    int minBlinkTime = 100;
    int maxBlinkTime = 400;

    // Time between blinks
    int minBlinkRate = 2000;
    int maxBlinkRate = 10000;

    void Start ()
    {
        m = GetComponent<M3DCharacterManager>();
        r = new System.Random();
        
        Invoke("BlinkTimer", r.Next(minBlinkRate, maxBlinkRate) / 1000);
    }

    void BlinkTimer()
    {
        StartCoroutine("Blink");
        Invoke("BlinkTimer", r.Next(minBlinkRate, maxBlinkRate) / 1000);
    }

    IEnumerator Blink ()
    {
        m.SetBlendshapeValue("PHMEyesClosedR", 100);
        m.SetBlendshapeValue("PHMEyesClosedL", 100);
        yield return new WaitForSeconds(r.Next(minBlinkTime, maxBlinkTime) / 1000f);
        m.SetBlendshapeValue("PHMEyesClosedR", 0);
        m.SetBlendshapeValue("PHMEyesClosedL", 0);
    }
}
