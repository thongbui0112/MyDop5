using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level {
    protected override void Awake() {
        base.Awake();
    }

    private void Update() {
        if(this.eraseController.StartErase && this.eraseController.Eraseable && this.eraseController.PlayingGame)
            CheckPoint();
        if(this.eraseController.FinishErase ) {
            this.eraseController.FinishErase = false;
            if(this.countCheckPoint < this.minCheckPointToVictory) {
                this.eraseController.DestroyErases();
                ResetCheckPointState();
            }
            else {
                this.eraseController.CanClick = false;
                Debug.Log("qua man");
                SetVictoryState();
                VictoryPanel();
            }
        }
    }

    public override void SetVictoryState() {
        for(int i = 0; i < 7; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 7; i < 13; i++) {
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
