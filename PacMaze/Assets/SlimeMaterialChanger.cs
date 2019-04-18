using System.Collections.Generic;
using UnityEngine;

public class SlimeMaterialChanger : MonoBehaviour
{
    public List<Material> mats;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        // Randomly pick a material from range 0 to all materials list content(length)
        rend.material = mats[Random.Range(0, mats.Count)];
    }
}
