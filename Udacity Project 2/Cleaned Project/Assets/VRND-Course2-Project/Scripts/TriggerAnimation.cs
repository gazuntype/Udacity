using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {
    public string AnimationName;
    public Animator stateMachine;

    private bool created = false;

    void Update() {
        GvrViewer.Instance.UpdateState(); //need to update the data here otherwise we dont get mouse clicks; this is because we are automatically creating the GVRSDK (seems like a bug)
        if (GvrViewer.Instance.Triggered)
            stateMachine.SetTrigger(AnimationName);
    }

}