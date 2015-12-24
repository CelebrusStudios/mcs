using UnityEngine;
using System.Collections;
using MORPH3D;

public class EyeControl : MonoBehaviour
{
    M3DCharacterManager m;
    System.Random r;

    // Blink time
    [Tooltip("The minimum length of time a blink will take.")]
    public int MinBlinkTime = 100;
    [Tooltip("The maximum length of time a blink will take.")]
    public int MaxBlinkTime = 400;

    // Time between blinks
    [Tooltip("The minimum length of time between blinks.")]
    public int MinBlinkRate = 2000;
    [Tooltip("The maximum length of time between blinks.")]
    public int MaxBlinkRate = 10000;

    void Start ()
    {
        m = GetComponent<M3DCharacterManager>();
        r = new System.Random();
        
        Invoke("BlinkTimer", r.Next(MinBlinkRate, MaxBlinkRate) / 1000);
    }

    void BlinkTimer()
    {
        StartCoroutine("Blink");
        Invoke("BlinkTimer", r.Next(MinBlinkRate, MaxBlinkRate) / 1000);
    }

    IEnumerator Blink ()
    {
        m.SetBlendshapeValue("PHMEyesClosedR", 100);
        m.SetBlendshapeValue("PHMEyesClosedL", 100);
        yield return new WaitForSeconds(r.Next(MinBlinkTime, MaxBlinkTime) / 1000f);
        m.SetBlendshapeValue("PHMEyesClosedR", 0);
        m.SetBlendshapeValue("PHMEyesClosedL", 0);
    }
}
