using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackSOBase : ScriptableObject
{
    protected Tower tower;
    protected Transform transform;
    protected GameObject gameObject;

    public virtual void Initialize(GameObject _gameObject, Tower _tower)
    {
        this.gameObject = _gameObject;
        transform = _gameObject.transform;
        this.tower = _tower;
    }
    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType) { }
}
