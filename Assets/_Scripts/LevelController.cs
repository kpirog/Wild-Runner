using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;
using System.Linq;
using Random = UnityEngine.Random;
using System;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level[] levelPrefabs;

    private IObjectPool<Level> levelPool;
    
    private int[] levelIndexes;
    private int levelCounter = 0;

    private float zOffset = 0f;

    [HideInInspector] public Func<Level> OnGameStarted;

    private void Awake()
    {
        levelPool = new ObjectPool<Level>(CreateLevel, OnGet, OnRelease, OnLevelDestroy, maxSize: levelPrefabs.Length);
        levelIndexes = new int[levelPrefabs.Length];

        for (int i = 0; i < levelIndexes.Length; i++)
        {
            levelIndexes[i] = i;
        }
    }
    private void OnEnable()
    {
        OnGameStarted += CreateLevel;
    }
    private void OnDisable()
    {
        
    }
    private Level CreateLevel()
    {
        if (levelCounter < levelPrefabs.Length)
        {
            Level newLevel = Instantiate(levelPrefabs[GetRandomLevelIndex()], Vector3.forward * zOffset, Quaternion.identity);
            newLevel.SetPool(levelPool);
            levelCounter++;

            return newLevel;
        }

        return null;
    }
    private void OnGet(Level level)
    {
        level.transform.position = Vector3.forward * zOffset;
        level.gameObject.SetActive(true);
        zOffset += 60f;
    }
    private void OnRelease(Level level)
    {
        level.gameObject.SetActive(false);
        level.transform.position = Vector3.zero;
    }
    private void OnLevelDestroy(Level level)
    {
        Destroy(level.gameObject);
    }
    private int GetRandomLevelIndex()
    {
        int randomIndex = levelIndexes[Random.Range(0, levelIndexes.Length)];
        levelIndexes = levelIndexes.Where(x => x != randomIndex).ToArray();

        return randomIndex;
    }
}
