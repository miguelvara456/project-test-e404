using Data;
using Events;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SpawnerManager : Singleton<SpawnerManager>
    {
        [Header("PoolObjects Variables")]
        [SerializeField] private GameObject baseObjectPrefab;
        [Header("Grid Spawn Variables")]
        [SerializeField] private int column, row;
        [SerializeField] private float startX, startY;
        [SerializeField] private float spaceX, spaceY;
        [Header("Events")]
        [SerializeField] private CustomEvent OnUpdateGame;
        [SerializeField] private CustomEvent startGame;
        private ObjectPool poolObjects;
        private float timerSpawnObjects;
        private float currentDelaySpawnObjects;
        public DataDifficulty data;

        private void Awake()
        {
            OnUpdateGame.OnEvent.AddListener(UpdateSpawn);
            startGame.OnEvent.AddListener(InitializeSpawn);
            InitializePoolObjects();
        }

        private void InitializeSpawn()
        {
            currentDelaySpawnObjects = Random.Range(data.MinTimeSpawn, data.MaxTimeSpawn);
            timerSpawnObjects = Time.time + currentDelaySpawnObjects;
        }

        private void UpdateSpawn()
        {
            if (Time.time > timerSpawnObjects)
            {
                timerSpawnObjects = Time.time + currentDelaySpawnObjects;
                currentDelaySpawnObjects = Random.Range(data.MinTimeSpawn, data.MaxTimeSpawn);
                var amountObjectSpawn = Random.Range(data.MinAmountToSpawn, data.MaxAmountToSpawn);
                SpawnGroup(amountObjectSpawn);
            }
        }

        private void InitializePoolObjects()
        {
            var content = new GameObject("ObjectsContent");
            var totalCount = column * row;
            poolObjects = new ObjectPool(totalCount, baseObjectPrefab,content.transform);

            for (int i = 0; i < totalCount; i++)
            {
                var newPos = new Vector3(startX + (spaceX * (i % column)), startY +(-spaceY * (i / column)),2f);
                poolObjects.SetInitialSpawnPosition(i,newPos);
            }
        }

        public void SpawnGroup(int amount,int obj = -1)
        {
            if (poolObjects.GetObjectsPoolDisactive() < amount) return;
            for (int i = 0; i < amount; i++)
            {
                var baseObjectParent = poolObjects.SpawnRandom();
                SpawnObject(obj,baseObjectParent.transform);
            }
        }

        private void SpawnObject(int typeObj,Transform parent)
        {
            Instantiate(GetTypeObject(typeObj), parent.position, Quaternion.identity,parent);
        }

        private GameObject GetTypeObject(int indexType)
        {
            if (indexType != -1)
                return data.Objects[indexType].objectToSpawn;
            else
                return data.Objects[ProbabilityCheckTypeObject()].objectToSpawn;
        }
        

        private int ProbabilityCheckTypeObject()
        {
            var rdm = Random.Range(0f, 1f);
            var numForAdding = 0f;
            var total = 0f;
            foreach (var obj in data.Objects)
                total += obj.chance;
            
            
            for (int i = 0; i < total; i++)
            {
                var chance = data.Objects[i].chance;
                if (chance / total + numForAdding >= rdm)
                    return i;
                else
                    numForAdding += chance / total;
            }
            return 0;
        }
    }
}