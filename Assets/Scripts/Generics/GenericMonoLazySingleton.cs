using UnityEngine;

// Script similar to a generic singleton class, except these are destroyed on scene change

namespace Generics
{
    public class GenericMonoLazySingleton<T> : MonoBehaviour where T : GenericMonoLazySingleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
