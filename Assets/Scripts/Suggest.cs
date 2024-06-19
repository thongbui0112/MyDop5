using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Suggest : MonoBehaviour
{
    [SerializeField] Button suggestButton;
    private void Start() {
         this.suggestButton = GetComponent<Button>();
        this.suggestButton.onClick.AddListener(SuggestButton);
    }
    public void SuggestButton() {
        Debug.Log("SuggestButton duoc nhan");
        GameObject levelHolder = GameObject.Find("LevelHolder");
        foreach (Transform t in levelHolder.transform) {
            if(t.name == "WinErase") {
                Animator suggestAnim =  t.gameObject.AddComponent<Animator>();
                AnimatorController controller = Resources.Load<AnimatorController>("SuggestAnimator");
                suggestAnim.runtimeAnimatorController = controller;
            }
        }
        this.gameObject.SetActive(false);
    }
}
