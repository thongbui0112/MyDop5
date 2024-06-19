using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour {


    [SerializeField] GameObject settingObj;
    [SerializeField] Button settingButton;
    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;
    [SerializeField] Button vibrateButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button supportButton;

    [SerializeField] Sprite[] musicSprite = new Sprite[2];
    [SerializeField] Sprite[] soundSprite = new Sprite[2];
    [SerializeField] Sprite[] vibrateSprite = new Sprite[2];
    private void Awake() {
        this.settingButton.onClick.AddListener(SettingButton);
        this.exitButton.onClick.AddListener(ExitButton);
        this.musicButton.onClick.AddListener(MusicButton);
        this.soundButton.onClick.AddListener(SoundButton);
        this.vibrateButton.onClick.AddListener(VibrateButton);
        this.settingObj.SetActive(false);

    }


    private IEnumerator Start() {
        yield return null;
        int musicIndex = AudioController.Instance.IsMusic;
        int soundIndex = AudioController.Instance.IsSound;
        int vibrateIndex = AudioController.Instance.IsVibrate;

        this.musicButton.gameObject.GetComponent<Image>().sprite = this.musicSprite[musicIndex];
        this.soundButton.gameObject.GetComponent<Image>().sprite = this.soundSprite[soundIndex];
        this.vibrateButton.gameObject.GetComponent<Image>().sprite = this.vibrateSprite[vibrateIndex];

    }

    public void SettingButton() {
        this.settingObj.SetActive(true);
        FindObjectOfType<EraseController>().PlayingGame = false;
    }

    public void ExitButton() {
        this.settingObj.SetActive(false);
        FindObjectOfType<EraseController>().PlayingGame = true;

    }

    public void MusicButton() {
        int musicIndex = (AudioController.Instance.IsMusic + 1) % 2;
        PlayerPrefs.SetInt("isMusic", musicIndex);
        AudioController.Instance.IsMusic = PlayerPrefs.GetInt("isMusic");
        this.musicButton.gameObject.GetComponent<Image>().sprite = this.musicSprite[musicIndex];
        AudioController.Instance.OnMusicChanged();
    }
    public void SoundButton() {
        int soundIndex = (AudioController.Instance.IsSound + 1) % 2;
        PlayerPrefs.SetInt("isSound", soundIndex);
        AudioController.Instance.IsSound = PlayerPrefs.GetInt("isSound");
        this.soundButton.gameObject.GetComponent<Image>().sprite = this.soundSprite[soundIndex];
    }
    public void VibrateButton() {
        int vibrateIndex = (AudioController.Instance.IsVibrate + 1) % 2;
        PlayerPrefs.SetInt("isVibrate", vibrateIndex);
        AudioController.Instance.IsVibrate = PlayerPrefs.GetInt("isVibrate");
        this.vibrateButton.gameObject.GetComponent<Image>().sprite = this.vibrateSprite[vibrateIndex];
    }


}
