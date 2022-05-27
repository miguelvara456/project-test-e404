using Data;
using Managers;
using UnityEngine;

public class Settings : MonoBehaviour
{
     [SerializeField] private DataDifficulty[] dataDifficulties;

     public void ChooiseDataDifficulties(int indexDifficulties)
     {
          SpawnerManager.Instance.data = dataDifficulties[indexDifficulties];
     }
}
