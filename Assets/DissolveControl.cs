using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DissolveControl : MonoBehaviour
{

    public float dissolveDuration = 2;
    public float dissolveStrength;

    public IEnumerator Dissolver()
    {
        float elapsedTime = 0;
        Material dissolveMaterial =  GetComponent<Renderer>().material;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveStength", dissolveStrength);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dissolver());
        }
    }



}

