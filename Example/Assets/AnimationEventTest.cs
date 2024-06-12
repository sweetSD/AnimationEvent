using UnityEngine;

public class AnimationEventTest : MonoBehaviour
{
    [SerializeField] private Animation.AnimationEvent animationEvent;
    [SerializeField] private GameObject attackCollider;
    
    void Awake()
    {
        animationEvent["MotionStarted"] += _ => Debug.Log($"Motion Started.");
        animationEvent["AttackStarted"] += @event => Debug.Log($"Attack Started with Int Param: {@event.intParameter}.");
        animationEvent["AttackStarted"] += _ => attackCollider.gameObject.SetActive(true);
        animationEvent["AttackEnded"] += OnAttackEnded;
    }

    private void OnAttackEnded(AnimationEvent @event)
    {
        Debug.Log($"Attack Ended with Float Param: {@event.floatParameter}.");
        attackCollider.gameObject.SetActive(false);
    }
}

