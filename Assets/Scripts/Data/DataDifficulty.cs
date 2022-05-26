using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DataDifficulty", menuName = "ScriptableObjects/Data/DataDifficulty", order = 0)]
    public class DataDifficulty : ScriptableObject
    {
        [SerializeField] private float minTimeSpawn;
        [SerializeField] private float maxTimeSpawn;
        [SerializeField] private float minAmountToSpawn;
        [SerializeField] private float maxAmountToSpawn;
        [SerializeField] private DataObject[] objects;

        public DataObject[] Objects => objects;
        public float MinTimeSpawn => minTimeSpawn;
        public float MaxTimeSpawn => maxTimeSpawn;
        public float MinAmountToSpawn => minAmountToSpawn;
        public float MaxAmountToSpawn => maxAmountToSpawn;
    }
    
    [Serializable]
    public class DataObject
    {
        public float chance;
        public GameObject objectToSpawn;
    }
}