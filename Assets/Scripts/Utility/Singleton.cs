using System;
using UnityEngine;

namespace Utility
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static readonly object Lock = new object();

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance != null) return instance;

                    instance = (T) FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                                       " - there should never be more than 1 singleton!" +
                                       " Reopening the scene might fix it.");
                        return instance;
                    }

                    if (instance == null)
                    {
                        var message = "[Singleton] No instances found!";

                        Debug.LogError(message);

                        throw new Exception(message);
                    }

                    return instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T) FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                                   " - there should never be more than 1 singleton!" +
                                   " Reopening the scene might fix it.");
                }

                if (instance == null)
                {
                    var message = "[Singleton] No instances found!";

                    Debug.LogError(message);

                    throw new Exception(message);
                }
            }
            else if (instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Debug.Log("Destroying instance...");
                Destroy(this);
            }
        }
    }
}