using UnityEngine;

namespace Tanks
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _plane;
        [SerializeField] private GameObject _player;


        private void Awake()
        {
            LoadResources.Init();
            ListControllers.Init();
            new PlayerBuilder();
            ListControllers.Add(new GlobalGameController(_plane, _player));
            // ListControllers.Add(new MoveController(_player));
        }

        private void Start()
        {
            ListControllers.Initialization();
        }

        private void Update()
        {
            // Profiler.BeginSample("StartExecute");
            ListControllers.Execute(Time.deltaTime);
            // Profiler.EndSample();
        }

        private void LateUpdate()
        {
            ListControllers.LateExecute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            ListControllers.FixedExecute(Time.deltaTime);
        }
    }
}