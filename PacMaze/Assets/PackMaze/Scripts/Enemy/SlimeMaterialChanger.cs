using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class SlimeMaterialChanger : MonoBehaviour
{
    public List<Material> mats;
    public Material flashMat;
    public float vulnerablity_duration = 5f;// Specifies how many seconds a slime will be vulnerable..

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


        StopCoroutine(Vulnerability_Detector());
        StartCoroutine(Vulnerability_Detector());
    }


    private void VulnrableSlime()
    {
        StopCoroutine(Blinking_and_Vulnerable());
        StartCoroutine(Blinking_and_Vulnerable());
    }

    IEnumerator Blinking_and_Vulnerable()
    {
        
        
        while(EnemyVulnerabilityController.instance.AllVulnerable)
        {

            rend.material = flashMat;

            yield return new WaitForSeconds(0.5f);

            rend.material = originalMat;

            yield return new WaitForSeconds(0.5f);

        }

    
    }

    IEnumerator Vulnerability_Detector()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (EnemyVulnerabilityController.instance.AllVulnerable == true)
            {
                //print("Vulnerable!");
                VulnrableSlime();
            }
        }
        
    }


    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
