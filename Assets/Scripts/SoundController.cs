using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = volumeSlider.value;
        volumeText.text = "" + (int) (volumeSlider.value * 100);
    }
}
