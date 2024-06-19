using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Star : MonoBehaviour {
    [SerializeField] Transform targetPoint;
    [SerializeField] List<Transform> stars;
    [SerializeField] List<Vector2> starsPos;
    [SerializeField] Animator trooperAnim;
    private void Awake() {
        foreach(Transform star in transform) {
            this.stars.Add(star);
            this.starsPos.Add(star.position);
        }
    }

    private void OnEnable() {
        StartCoroutine(ActiveStars());
    }

    private IEnumerator ActiveStars() {
        yield return null;
        for(int i = 0; i < this.stars.Count; i++) {
            this.stars[i].gameObject.SetActive(false);
            this.stars[i].position = this.starsPos[i];
        }
        for(int i = 0; i < this.stars.Count; i++) {
            this.stars[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update() {
        StartCoroutine(MoveStarsToTarget());
    }

    public IEnumerator MoveStarsToTarget() {
        yield return new WaitForSeconds(0.7f);
        for(int i = this.stars.Count - 1; i >= 0; i--) {
            MoveToTarget(this.stars[i]);
            if(Vector2.Distance(this.stars[i].position, this.targetPoint.position) <= 0.5f) {
                if(this.stars[i].gameObject.activeSelf) {
                    this.trooperAnim.SetTrigger("shake");
                    StartCoroutine(AudioController.Instance.PlayStarVibrate());
                }
                this.stars[i].gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void MoveToTarget(Transform star) {
        star.position = Vector2.MoveTowards(star.position, targetPoint.position, 0.4f);
    }

}
