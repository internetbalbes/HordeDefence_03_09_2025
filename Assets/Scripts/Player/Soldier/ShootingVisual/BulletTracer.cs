using UnityEngine;
using System.Collections;

public class BulletTracer : MonoBehaviour
{
    private Vector3 _target;
    private float _speed;
    private bool _isActive = false;

    public void Shoot(Vector3 start, Vector3 target, float speed)
    {
        transform.position = start;
        _target = target;
        _speed = speed;

        if (!_isActive)
        {
            _isActive = true;
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, _target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            yield return null;
        }

        _isActive = false;
        gameObject.SetActive(false); // отключаем пулю после долёта
    }
}
