using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Spawners
{
    public class ItemSpawner
    {
        private DiContainer _container;
        private List<GameObject> _items;
        private List<Transform> _transforms;

        public ItemSpawner(DiContainer container, List<GameObject> items, List<Transform> transforms)
        {
            _container = container;
            _items = items;
            _transforms = transforms;
        }

        public void RandomlySpawnItems(List<GameObject> items, List<Transform> transforms)
        {
            foreach (var transform in transforms)
            {
                GameObject randomItem = items[Random.Range(0, items.Count)];
                SpawnItem(randomItem, transform.position, Quaternion.identity);
            }
        }

        public void RandomlySpawnItems()
        {
            foreach (var transform in _transforms)
            {
                GameObject randomItem = _items[Random.Range(0, _items.Count)];
                SpawnItem(randomItem, transform.position, Quaternion.identity);
            }
        }

        private void SpawnItem(GameObject item, Vector3 postions, Quaternion rotation) 
        {
            _container.InstantiatePrefab(item,postions,rotation, null);
        }
    }
}