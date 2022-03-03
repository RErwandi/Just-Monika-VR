using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace JustMonika.VR
{
    [GlobalConfig("_Productions/Resources/Configs/")]
    public class GameConfig : GlobalConfig<GameConfig>
    {
        public List<AffectionSetting> affectionSettings = new List<AffectionSetting>();
    }
}