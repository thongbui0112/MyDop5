using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level26 : Level
{
    protected override void Awake() {
        base.Awake();
    }

    private void Update() {
        if(this.eraseController.StartErase && this.eraseController.Eraseable && this.eraseController.PlayingGame) {
            CheckPoint();
        }
        if(this.eraseController.FinishErase) {
            this.eraseController.FinishErase = false;
            if(this.countCheckPoint >= this.minCheckPointToVictory && this.countNoCheckPoint == 0) {
                this.eraseController.CanClick = false;
                Debug.Log("qua man");
                SetVictoryState();
                VictoryPanel();
            }
            else {
                this.eraseController.DestroyErases();
                ResetCheckPointState();
            }
        }
    }



    public override void SetVictoryState() {
        for(int i = 0; i < 1; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 1; i < 3; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public override void CheckPoint() {
        base.CheckPoint();
    }

    public override void ResetCheckPointState() {
        base.ResetCheckPointState();
    }
}
