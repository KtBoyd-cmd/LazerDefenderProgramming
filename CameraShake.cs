using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeduration = 1f;
    [SerializeField] float shakeamount = 0.5f;

    Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while(elapsedTime < shakeduration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeamount;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
    }
    }
    
}
