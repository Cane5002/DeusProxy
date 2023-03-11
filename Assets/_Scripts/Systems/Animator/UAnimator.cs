using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAnimator : DeterministicMonoBehaviour{
    private SpriteRenderer sprite;
    new private UAnimation animation;

    private int frame;

    protected override void GameStart() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Play(UAnimation _animation, int startFrame = 0) {
        animation = _animation;
        frame = startFrame;
    }

    protected override void GamePhysicsUpdate() {
        frame++;
    }

    private void ExitAnimation() {

    }

}
