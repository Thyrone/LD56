using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Material _crying;
    [SerializeField] private Material _idle;
    [SerializeField] private HeartType _type;

    private MeshRenderer _renderer;

    public enum HeartType
    {
        Joy,
        Anxiety,
        Crazy,
    }

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Cry()
    {
        _renderer.material = _crying;
    }

    public void StopCrying()
    {
        _renderer.material = _idle;
    }

    public void Die()
    {
        _renderer.material = _crying;
    }
}
