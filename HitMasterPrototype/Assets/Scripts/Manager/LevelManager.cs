using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] LevelSetting _levelSetting;
    int _playerPlatformNum = 0;
    Dictionary<int, List<Enemy>> _enemyDict = new Dictionary<int, List<Enemy>>();
    void Start()
    {
        CreateLevel();
    }
    void CreateLevel()
    {
        for (int i = 0; i < _levelSetting.platformsList.Count; i++)
        {
            for (int j = 0; j < _levelSetting.platformsList[i].posList.Length; j++)
            {
                var enemy = Instantiate(_enemyPrefab, _levelSetting.platformsList[i].posList[j],transform.rotation);
                enemy.platformNum = _levelSetting.platformsList[i].platformNum;
                enemy.hitEvent += Enemy_hitEvent;
                if (!_enemyDict.ContainsKey(_levelSetting.platformsList[i].platformNum))
                {
                    _enemyDict.Add(_levelSetting.platformsList[i].platformNum, new List<Enemy>());
                }
                _enemyDict[_levelSetting.platformsList[i].platformNum].Add(enemy);
            }
        }
    }

    private void Enemy_hitEvent(int pNum, Enemy obj)
    {
        obj.hitEvent -= Enemy_hitEvent;
        _enemyDict[pNum].Remove(obj);
        if (_enemyDict.ContainsKey(_playerPlatformNum))
        {
            GameManager.Instence.FindNearEnemy(_enemyDict[_playerPlatformNum]);
            if (_enemyDict[_playerPlatformNum].Count == 0 && _playerPlatformNum == pNum)
            {
                GameManager.Instence.PlayerMoveNextPos();
            }
        }
        
    }
    public bool EnemyCheck(int pNum)
    {
        _playerPlatformNum = pNum;
        if(!_enemyDict.ContainsKey(pNum) || _enemyDict[pNum].Count == 0)
        {
            return true;
        }
        else
        {
            GameManager.Instence.FindNearEnemy(_enemyDict[pNum]);
            return false;
        }
    }
}
