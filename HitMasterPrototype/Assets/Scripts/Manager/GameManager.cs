using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isStart;
    public LevelManager lManager;

    int _nextPosIndex;
    [SerializeField] PlayerNavMeshMove _player;
    [SerializeField] Transform[] _posList;
    [SerializeField] PlayerLookAt _playerLookAt;

    public void StartGame()
    {
        if (!isStart)
        {
            PlayerMoveNextPos();
            isStart = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void OnPosition(int pNum)
    {
        bool isCan =  lManager.EnemyCheck(pNum);
        if(isCan)
        {
            PlayerMoveNextPos();
        }
    }
    public void PlayerMoveNextPos()
    {
        if (_nextPosIndex < _posList.Length)
        {
            _player.MovePlayer(_posList[_nextPosIndex].position);
        }
        _nextPosIndex++;
    }
    public void FindNearEnemy(List<Enemy> eList)
    {
        Vector3 nearPos = _player.transform.position;
        float startDist = Mathf.Infinity;
        if (eList != null && eList.Count > 0)
        {
            foreach (var i in eList)
            {
                float dist = Vector3.Distance(_player.transform.position, i.transform.position);
                if (dist < startDist)
                {
                    startDist = dist;
                    nearPos = i.transform.position;
                }
            }
            _playerLookAt.PlayerRotate(nearPos);
        }
        _playerLookAt.PlayerRotate(nearPos);
    }
}
