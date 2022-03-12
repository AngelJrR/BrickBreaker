using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour
{

    public AudioClip breaking;
    public bool broken = false;
    private AudioSource soundAudio;

    // Start is called before the first frame update
    void Start()
    {
        soundAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Sounds()
    {
        soundAudio.PlayOneShot(breaking, 1f);
    }
}
