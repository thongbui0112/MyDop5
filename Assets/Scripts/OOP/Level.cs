using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    public int countCheckPoint;
    public int countNoCheckPoint;
    public int minCheckPointToVictory;
    public float distanceToCheckPoint;

    public List<Vector2> noCheckPoint;
    public List<Vector2> checkPoint;
    public List<bool> checkPointState;
    public List<bool> noCheckPointState;
    public GameObject mouseSprite;
    public EraseController eraseController;

    public GameObject victoryPanel;

    protected virtual void Awake() {
        this.distanceToCheckPoint = 0.8f;
        this.checkPoint = new List<Vector2>();
        this.checkPointState = new List<bool>();
        this.eraseController = FindObjectOfType<EraseController>();
        this.mouseSprite = FindObjectOfType<EraseController>().MouseSprite;
        StartCoroutine(GetAllCheckPoint());
    }



    public virtual void SetTargetPoint() {

    }

    public IEnumerator GetAllCheckPoint() {
        yield return new WaitForSeconds(0.1f);
        foreach(Transform child in transform) {
            if(child.name == "CheckPoint") {
                this.checkPoint.Add(child.position);
                this.checkPointState.Add(false);
            }
        }
        this.minCheckPointToVictory = this.checkPoint.Count;
    //    this.eraseController.SetNewLevel();
    }

    public virtual void CheckPoint() {
        for(int i = 0; i < checkPoint.Count; i++) {
            if(Vector2.Distance(this.checkPoint[i], this.mouseSprite.transform.position) <= this.distanceToCheckPoint) {
                if(!this.checkPointState[i]) {
                    this.checkPointState[i] = true;
                    this.countCheckPoint++;
                }
            }
        }
    }

    public virtual void ResetCheckPointState() {
        this.countCheckPoint = 0;
        for(int i = 0; i < this.checkPointState.Count; i++) {
            this.checkPointState[i] = false;
        }
    }

    public void VictoryPanel() {
        AudioController.Instance.PlayWonSound();
        GameObject victoryPanel = GameObject.Find("VictoryPanel");
        StartCoroutine(victoryPanel.GetComponent<VictoryPanel>().ActiveComponent());
        this.eraseController.DestroyErases();
        LevelController.Instance.LevelFinished();

        GameObject suggestButton = GameObject.Find("SuggestButton");
        suggestButton.SetActive(false);
    }


    public virtual IEnumerator GetAllNoCheckPoint() {
        yield return new WaitForSeconds(0.1f);
        foreach(Transform child in transform) {
            if(child.name == "NoCheckPoint") {
                this.noCheckPoint.Add(child.position);
                this.noCheckPointState.Add(false);
            }
        }
    }
    public virtual void NoCheckPoint() {
        for(int i = 0; i < noCheckPoint.Count; i++) {
            if(Vector2.Distance(this.noCheckPoint[i], this.mouseSprite.transform.position) <= this.distanceToCheckPoint) {
                if(!this.noCheckPointState[i]) {
                    this.noCheckPointState[i] = true;
                    this.countNoCheckPoint++;
                }
            }
        }
    }

    public virtual void ResetNoCheckPointState() {
        this.countNoCheckPoint = 0;
        for(int i = 0; i < this.noCheckPointState.Count; i++) {
            this.noCheckPointState[i] = false;
        }
    }

    public virtual void SetVictoryState() {

    }

}
