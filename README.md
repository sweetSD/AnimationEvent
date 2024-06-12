# AnimationEvent

애니메이션 이벤트를 쉽게 받을 수 있도록 도와주는 스크립트입니다.

## How to use
1. 유니티 프로젝트 아무곳에나 AnimationEvent.cs 파일을 넣어주세요.
2. 원하는 애니메이션 이벤트를 추가합니다. \
![image](https://github.com/sweetSD/AnimationEvent/assets/29685039/56d1d520-aa62-4b17-9cdb-53a6e6c2eea8)
![image](https://github.com/sweetSD/AnimationEvent/assets/29685039/cb1b506c-512e-470c-93da-92c1a5f203d6)
![image](https://github.com/sweetSD/AnimationEvent/assets/29685039/2b7d553b-946b-42ce-99a7-314091c42db6)

3. 이벤트를 받고싶은 Animator 컴포넌트가 있는 곳에 AnimationEvent 컴포넌트를 추가해주세요.
![image](https://github.com/sweetSD/AnimationEvent/assets/29685039/2188835c-5371-4329-bcf1-dd81f2b911f3)
4. 이벤트를 받아서 처리하는 스크립트를 제작해주세요.
```
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
```
5. 적용 결과\
![animEvent2](https://github.com/sweetSD/AnimationEvent/assets/29685039/4d72819e-585f-41e9-8d49-f95d1a25782f)

히트 판정 타이밍 조절할 때 편하게 할 수 있습니다.

