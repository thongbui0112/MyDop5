using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    private static AudioController instance;
    public static AudioController Instance {
        get {
            if(instance == null) {
                instance = FindObjectOfType<AudioController>();
            }
            return instance;
        }
    }


    AudioSource audioSource;
    [SerializeField] private AudioClip wonSound;
    [SerializeField] int isSound, isMusic, isVibrate;
    public int IsSound { get => isSound; set => isSound = value; }
    public int IsMusic { get => isMusic; set => isMusic = value; }
    public int IsVibrate { get => isVibrate; set => isVibrate = value; }
    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();

        GetSettings();
        PlayMusic();
    }

    public void PlayWon() {
        PlayWonSound();
        StartCoroutine(PlayWonVibrate());
    }

    public void PlayWonSound() {
        if(IsSound == 0)
            this.audioSource.PlayOneShot(wonSound);
    }

    public IEnumerator PlayWonVibrate() {
        if(this.IsVibrate == 0) {
            Handheld.Vibrate();
            yield return new WaitForSeconds(0.3f);
            Handheld.Vibrate();
        }
    }

    public IEnumerator PlayStarVibrate() {
        if(this.IsVibrate == 0) {
            Handheld.Vibrate();
            yield return new WaitForSeconds(0.1f);
            Handheld.Vibrate();
        }
    }

    public void PlayMusic() {
        if(IsMusic == 0)
            this.audioSource.Play();
    }
    private void GetSettings() {
        if(PlayerPrefs.HasKey("isSound"))
            this.IsSound = PlayerPrefs.GetInt("isSound");
        else
            this.IsSound = 0;

        if(PlayerPrefs.HasKey("isMusic"))
            this.IsMusic = PlayerPrefs.GetInt("isMusic");
        else
            this.IsMusic = 0;

        if(PlayerPrefs.HasKey("isVibrate"))
            this.IsVibrate = PlayerPrefs.GetInt("isVibrate");
        else
            this.IsVibrate = 0;
    }

    public void OnMusicChanged() {
        if(this.IsMusic == 0)
            this.audioSource.Play();
        else
            this.audioSource.Stop();
    }

}
