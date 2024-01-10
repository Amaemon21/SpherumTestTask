using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _spawnRate = 10f;    
    [SerializeField] private float _particleSpeed = 5f;    
    [SerializeField] private float _particleSize = 0.2f;  
    [SerializeField] private float _bounding = 5f;

    [Space(5)]
    [SerializeField] private ParticleTypes _particleTypes;

    private float _timer;

    private ParticleSystem.Particle[] _particles;

    private enum ParticleTypes
    {
        Box,
        Sphere
    }

    private void Awake()
    {
        _particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 1f / _spawnRate)
        {
            EmitParticle();
            _timer = 0f;
        }

        UpdateParticles();
    }

    private void EmitParticle()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-_bounding / 2f, _bounding / 2f),
            Random.Range(-_bounding / 2f, _bounding / 2f),
            Random.Range(-_bounding / 2f, _bounding / 2f)
        );

        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = spawnPosition;
        emitParams.velocity = Random.onUnitSphere * _particleSpeed;
        emitParams.startLifetime = Mathf.Infinity;
        emitParams.startSize = _particleSize;

        _particleSystem.Emit(emitParams, 1);
    }

    private void UpdateParticles()
    {
        int numParticlesAlive = _particleSystem.GetParticles(_particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            if (!IsInsideBounding(_particles[i].position))
            {
                _particles[i].position = Vector3.zero;
                _particles[i].velocity = Random.onUnitSphere * _particleSpeed;
            }
        }

        _particleSystem.SetParticles(_particles, numParticlesAlive);
    }

    private bool IsInsideBounding(Vector3 position)
    {
        if (_particleTypes == ParticleTypes.Sphere)
        {
            return position.magnitude < _bounding;
        }
        else
        {
            return Mathf.Abs(position.x) < _bounding / 2f &&
                      Mathf.Abs(position.y) < _bounding / 2f &&
                      Mathf.Abs(position.z) < _bounding / 2f;
        }

        return false;
    }
}