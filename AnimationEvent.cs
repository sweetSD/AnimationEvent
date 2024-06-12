using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class AnimationEvent : MonoBehaviour
    {
        private readonly Dictionary<string, Action<UnityEngine.AnimationEvent>> eventActionDictionary = new();

        public Action<UnityEngine.AnimationEvent> this[string eventName]
        {
            get
            {
                if (!eventActionDictionary.TryGetValue(eventName, out _))
                {
                    eventActionDictionary[eventName] = _ => { };
                }

                return eventActionDictionary[eventName];
            }
            set => eventActionDictionary[eventName] = value;
        }

        public event Action<UnityEngine.AnimationEvent> onEvent;

        public virtual void OnEvent(UnityEngine.AnimationEvent message)
        {
            if (eventActionDictionary.TryGetValue(message.stringParameter, out var action))
            {
                action?.Invoke(message);
            }

            onEvent?.Invoke(message);
        }
    }
}