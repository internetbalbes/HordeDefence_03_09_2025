using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject pawnPrefab;
    public Transform enemySpawnZone;
    public RoundManager roundManager;

    private Queue<GameObject> _pawnList = new Queue<GameObject>();

    private float _timer = 0f;
    private float _timeToSpawn = 0f;

    private int _roundPowerPointsUsed = 0;
    private bool _isRoundStarted = false;

    private int _roundPowerPoints = 0;

    public void NewPawn()
    {
        GameObject pawn = Instantiate(pawnPrefab);
        _pawnList.Enqueue(pawn);
        pawn.SetActive(false);
    }

    public void Enqueue(GameObject pawn)
    {
        _pawnList.Enqueue(pawn);
    }

    public void PullPawn()
    {
        GameObject pawn = _pawnList.Dequeue();

        pawn.transform.position = new Vector3
        (
            Random.Range(-3, 3),
            enemySpawnZone.position.y,
            enemySpawnZone.position.z
        );

        pawn.SetActive(true);
    }

    public void StartRound(int roundPowerPoints)
    {
        _isRoundStarted = true;
        
        for (int i = 0; i < roundPowerPoints - _roundPowerPoints; i++)
        {
            NewPawn();
        }

        _roundPowerPoints = roundPowerPoints;
    }

    private void Update()
    {
        if (_isRoundStarted)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToSpawn)
            {
                PullPawn();
                _timer = 0f;
                TimeToSpawnRandomizer();
                _roundPowerPointsUsed++;

                if (_roundPowerPointsUsed == _roundPowerPoints)
                {
                    _isRoundStarted = false;
                }
            }
        }
    }

    private float TimeToSpawnRandomizer()
    {
        _timeToSpawn = Random.Range(0.25f, 0.75f);
        return _timeToSpawn;
    }
}
