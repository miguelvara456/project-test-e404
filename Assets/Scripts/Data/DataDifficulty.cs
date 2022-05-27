using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DataDifficulty", menuName = "ScriptableObjects/Data/DataDifficulty", order = 0)]
    public class DataDifficulty : ScriptableObject
    {
        [SerializeField] private float minTimeSpawn;
        [SerializeField] private float maxTimeSpawn;
        [SerializeField] private int minAmountToSpawn;
        [SerializeField] private int maxAmountToSpawn;
        [SerializeField] private DataObject[] objects;

        public DataObject[] Objects => objects;
        public float MinTimeSpawn => minTimeSpawn;
        public float MaxTimeSpawn => maxTimeSpawn;
        public int MinAmountToSpawn => minAmountToSpawn;
        public int MaxAmountToSpawn => maxAmountToSpawn;
    }
    
    [Serializable]
    public class DataObject
    {
        public float chance;
        public GameObject objectToSpawn;
    }
}