using System;
using UnityEngine;

namespace Tanks
{
    internal sealed class GlobalGameController : IController, IExecute

    {
    private GameObject _plane;

    private GameObject _player;
    // private GameModel _gameModel;
    // private string _nameGameCfg = "GameCfg";
    // private GameCfg _gameCfg;

    public GlobalGameController(GameObject plane, GameObject player)
    {
        _plane = GameObject.Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        // _player = GameObject.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        // _gameModel = new GameModel();
        // Reference.AddGameModel(_gameModel);
        // LoadCfg(_nameGameCfg, (obj) =>
        // {
        //     _gameCfg = (GameCfg)obj;
        //     Reference.AddGameCfg(_gameCfg);
        //
        //     AddController(new GameController(_gameModel));
        // InitUnity();
        // }
        // );
    }

    private void InitUnity()
    {
        Application.targetFrameRate = 1000;
    }

    public event Action<IController> EvtNeedDestroy;
    public void Execute(float deltaTime)
    {
        // Debug.Log($"Execute");
    }
    }
}
