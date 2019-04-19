using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class SlimeMaterialChanger : MonoBehaviour
{
    public List<Material> mats;
    public Material flashMat;
    public int blinking_times = 15;

    private Renderer rend;
    private Material originalMat;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        // Randomly pick a material from range 0 to all materials list content(length)
        rend.material = mats[Random.Range(0, mats.Count)];
        originalMat = rend.material;
    }


    public void VulnrableSlime()
    {
        StopCoroutine(Blinking());
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        for (int i = 0; i<= blinking_times; i++)
        {
            rend.material = flashMat;

            yield return new WaitForSeconds(0.5f);

            rend.material = originalMat;

            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
