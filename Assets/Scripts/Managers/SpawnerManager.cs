using System;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private GameObject baseObjectPrefab;
        [SerializeField] private int countX, countY;
        [SerializeField] private float startX, startY;
        [SerializeField] private float spaceX, spaceY;
        private ObjectPool poolObjects;
        private void Start()
        {
            InitializePoolObjects();
        }

        private void InitializePoolObjects()
        {
            var content = new GameObject("ObjectsContent");
            var totalCount = countX * countY;
            poolObjects = new ObjectPool(totalCount, baseObjectPrefab,content.transform);

            for (int i = 0; i < totalCount; i++)
            {
                var newPos = new Vector3(startX + (spaceX * (i % countX)), startY +(-spaceY * (i / countX)),2f);
                poolObjects.SetInitialSpawnPosition(i,newPos);
            }
        }
    }
}