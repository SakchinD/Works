using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public SpawnPositions positions;
    public bool isCleared { get; private set; }
    [SerializeField] TMP_Text _text, _finaleScore;
    [SerializeField] LevelEnemyList _levelEnemyList;
    [SerializeField] Image _count;
    [SerializeField] GameObject _completedPlan,_missionComp;
    [SerializeField] float _maxHabitat, _cleredTime;
    private float _habitatLeft;
    private float _time;
    private float _score;
    private bool _onClear = true;
    private void Awake()
    {
        _habitatLeft = _maxHabitat;
        if (_levelEnemyList)
        {
            var s = Instantiate(_levelEnemyList);
            _levelEnemyList = s;
        }
    }
    private void Update()
    {
        if (!GameManager.Instence.inPauseState)
        {
            _time += Time.deltaTime;
            GetObject(_levelEnemyList);
            if (_count)
            {
                _count.fillAmount = _habitatLeft / _maxHabitat;
            }
        }
        if (isCleared)
        {
            _cleredTime -= Time.deltaTime;
            if (_cleredTime <= 0 && _onClear)
            {
                MissionClear();
            }
        }
    }
    void GetObject(LevelEnemyList list)
    {
        if (list)
        {
            for (int i = 0; i < list.list.Count; i++)
            {
                var s = list.list[i];
                if (s.time <= _time)
                {
                    var obj = ObjectPool.Instence.GetPooledObject(s.name);
                    obj.transform.position = positions.posirionsList[s.posNumb].position;
                    obj.SetActive(true);
                    list.list.Remove(s);
                }
            }
        }
    }
    public void HabitatLeftDecrease()
    {
        _habitatLeft--;
        if (_habitatLeft <= 0)
        {
            _missionComp.SetActive(true);
            isCleared = true;            
        }
    }
    public void GetScore(float score)
    {
        _score += score;
        if (_text)
        {
            _text.text = $"Score : {_score}";
        }
    }
    private void MissionClear()
    {
        _finaleScore.text = $"Finale Score : {_score}";
        GameManager.Instence.StartPause();
        AudioManager.Instence.AudioPlay("LevelCleared");
        _completedPlan.gameObject.SetActive(true);
        _onClear = false;
    }
}
