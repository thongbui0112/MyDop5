using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    [SerializeField] GameObject suggestButton;
    public GameObject itemPref;
 //   [SerializeField] LevelData levelData;
    LevelController levelController;
    private void Start() {
        this.levelController = FindObjectOfType<LevelController>();
    }
    private void Reset() {

    }
    public IEnumerator LoadLevel(LevelData levelData) {


        yield return null;
        Transform levelHolder = GameObject.Find("LevelHolder").transform;
        Debug.Log(levelHolder);
        for(int i = 0; i < levelData.numberOfItem; i++) {
            GameObject.Find("Level_txt").GetComponent<TMP_Text>().text = levelData.name;
            GameObject.Find("Request_txt").GetComponent<TMP_Text>().text = levelData.request;
            GameObject newItem = Instantiate(itemPref, levelHolder);
            newItem.name = levelData.nameItem[i];
            newItem.SetActive(levelData.state[i]);
            newItem.GetComponent<SpriteRenderer>().sprite = levelData.sprite[i];
            newItem.transform.position = levelData.pos[i];
            newItem.transform.rotation = levelData.rot[i];
            newItem.transform.localScale = levelData.scale[i];
            newItem.GetComponent<SpriteRenderer>().sortingOrder = levelData.sortingOrder[i];
            if(levelData.eraseable[i]) {
                yield return null;
                newItem.layer = LayerMask.NameToLayer("Eraseable");
                newItem.AddComponent<PolygonCollider2D>();
                newItem.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }

        }

        yield return new WaitForSeconds(.4f);
        this.suggestButton.SetActive(true);
    }
}
