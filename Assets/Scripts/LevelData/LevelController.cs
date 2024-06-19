using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelController : MonoBehaviour {
    private static LevelController instance;
    public static LevelController Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<LevelController>();
            return instance;
        }
    }

    [SerializeField] private int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }

    [SerializeField] GameObject levelHolderPref;

    LoadLevelData loadLevelData;

    [SerializeField] int maxLevel;
    private void Awake() {
        this.currentLevel = GetCurrentLevel();  
        loadLevelData = FindObjectOfType<LoadLevelData>();
        StartCoroutine(CreateLevel());
    }


    IEnumerator CreateLevel() {

        Debug.Log("Currenlevel" + this.currentLevel.ToString());
        GameObject levelHolder = Instantiate(levelHolderPref);
        levelHolder.name = "LevelHolder";

        string levelName = "Level" + this.CurrentLevel;
        LevelData levelData = Resources.Load<LevelData>(levelName.ToString());

        StartCoroutine(this.loadLevelData.LoadLevel(levelData));
        yield return new WaitForSeconds(0.1f);

        Type scriptType = Type.GetType(levelName);
        levelHolder.AddComponent(scriptType);
    }

    public IEnumerator NextLevel() {

        Destroy(GameObject.Find("LevelHolder"));
        yield return null;
        StartCoroutine(CreateLevel());
    }

    private void Start() {

    }
    private void Reset() {
        PlayerPrefs.DeleteKey("CurrentLevel");
    }

    private int GetCurrentLevel() {
  //      PlayerPrefs.DeleteKey("CurrentLevel");
        if(PlayerPrefs.HasKey("CurrentLevel"))
            return PlayerPrefs.GetInt("CurrentLevel")  ;
        else
            return currentLevel = 1;
    }
    public void LevelFinished() {
        this.currentLevel++;
        if(this.currentLevel == maxLevel + 1)
            this.currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", this.currentLevel);
    }

}
