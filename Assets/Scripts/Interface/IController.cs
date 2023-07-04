using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

namespace Tanks
{
    public interface IController
    {
        event Action<IController> EvtNeedDestroy;
    }

    public interface IControllerAddressable
    {
        public event Action EvtAddressableCompleted;
    }
}
