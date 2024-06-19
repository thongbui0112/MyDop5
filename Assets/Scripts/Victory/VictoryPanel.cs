using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] GameObject star, nextLevelButton, confetti;
    LevelController levelController;
    EraseController eraseController;
    private void Awake() {
        this.levelController = FindObjectOfType<LevelController>();
        this.eraseController = FindObjectOfType<EraseController>();
    }

    public IEnumerator ActiveComponent() {
        this.star.SetActive(false);
        this.nextLevelButton.SetActive(false);
        this.confetti.SetActive(true);
        yield return new WaitForSeconds(0f);
        this.star.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        this.nextLevelButton.SetActive(true);
        this.confetti.SetActive(false);
        
    }



    public void NextLevelButton() {
        this.eraseController.DestroyErases();
        StartCoroutine(this.eraseController.SetNewLevel());
        StartCoroutine(this.levelController.NextLevel());
        HideComponent();
    }



    private void HideComponent() {

        this.star.SetActive(false);
        this.nextLevelButton.SetActive(false);
    }
}
