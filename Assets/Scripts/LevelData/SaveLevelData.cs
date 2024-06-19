using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveLevelData : MonoBehaviour {
    [SerializeField] int currentLevel;
    [SerializeField] Transform levelHolder;

    private void Reset() {
        this.levelHolder = GameObject.Find("LevelHolder").transform;
        CreateNewLevelData();
    }

    void CreateNewLevelData() {
        //   yield return null;
        LevelData _levelData = ScriptableObject.CreateInstance<LevelData>();
        //   _levelData.name = "Level" + this.currentLevel.ToString();
        _levelData.name = gameObject.GetComponent<NameLevel>().nameLevel;
        InitializationLevelData(_levelData);

        for(int i = 0; i < this.levelHolder.childCount; i++) {
            Debug.Log(_levelData.numberOfItem);
            GameObject currentItem = this.levelHolder.GetChild(i).gameObject;
            _levelData.nameItem[i] = currentItem.name;
            _levelData.state[i] = currentItem.activeSelf;
            _levelData.eraseable[i] = currentItem.layer == LayerMask.NameToLayer("Eraseable") ? true : false;

            _levelData.sprite[i] = currentItem.GetComponent<SpriteRenderer>().sprite;
            _levelData.sortingOrder[i] = currentItem.GetComponent<SpriteRenderer>().sortingOrder;

            _levelData.pos[i] = currentItem.transform.position;
            _levelData.rot[i] = currentItem.transform.rotation;
            _levelData.scale[i] = currentItem.transform.localScale;
        }
#if UNITY_EDITOR
        string path = "Assets/Resources/" + _levelData.name.ToString() + ".asset";
        AssetDatabase.CreateAsset(_levelData, path);
        AssetDatabase.SaveAssets();
#endif
    }

    private void InitializationLevelData(LevelData _levelData) {
        _levelData.numberOfItem = this.levelHolder.childCount;

        _levelData.nameItem = new string[_levelData.numberOfItem];
        _levelData.state = new bool[_levelData.numberOfItem];
        _levelData.eraseable = new bool[_levelData.numberOfItem];
        _levelData.sprite = new Sprite[_levelData.numberOfItem];
        _levelData.sortingOrder = new int[_levelData.numberOfItem];
        _levelData.pos = new Vector2[_levelData.numberOfItem];
        _levelData.rot = new Quaternion[_levelData.numberOfItem];
        _levelData.scale = new Vector3[_levelData.numberOfItem];
    }



}
