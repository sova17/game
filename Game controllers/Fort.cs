using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class Fort: FightingUnit
{
    public Fort(string name, int creationYear, Nation creationNation,
                Nation playingNation, int level, int experience, 
                Storage storage, BindedParametersController _base,
	            BalancingParametersController current, CannonKind cannonKind,
	            CannonBallKind cannonBallKind, Cell currentCell):              base(name, creationYear, creationNation,
                                                                                    playingNation, level, experience, storage,
                                                                                    _base, current, cannonKind, cannonBallKind,
                                                                                    currentCell)
     {}
}