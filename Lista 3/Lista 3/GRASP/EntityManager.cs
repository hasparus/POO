using System.Collections.Generic;
using UnityEngine;

namespace Lista_3.GRASP
{

    /* GRASP: CREATOR
     * 
     * Dobra, kod jest kompilujący się, ale nie działający,
     * bo chciałem pokazać coś co działało w moim projekcie w praktyce
     * i tu są aż dwa przykłady Creatora.
     * 
     * */
    public class Entity
    {
        public int Id;
        public Transform transform;

        public Entity(int id) { }
    }

    public class EntitySpawner
    {}

    public class EntityManager : MonoBehaviour
    {
        private int _highestKey = 0;
        public Dictionary<int, Entity> Hash;
        public EntitySpawner[] Spawners;

        // PASKUDNE WYWOŁANIE METODY PO NAZWIE PRZEZ REFLEKSJĘ.
        // Unity tworzy wszystkie MonoBehaviory przez wywołanie na nich Awake() i Start()
        void Start() 
        {
            Hash = new Dictionary<int, Entity>(); 
            // w ogóle mi się ciężko żyje bez wrappera na Dictionary<> który zmienia wyjątek w nulla
            // zapytać dlaczego domyślnie jest z wyjątkiem, chociaż w implementacji jest ten null
        }

        void Update()
        {
        }

        public void CreateEntity()
        {
            Hash[_highestKey] = new Entity(_highestKey);
            _highestKey++;
        }

        public void DeleteEntity(Entity e)
        {
            Hash[e.Id] = null;
        }
    }
}