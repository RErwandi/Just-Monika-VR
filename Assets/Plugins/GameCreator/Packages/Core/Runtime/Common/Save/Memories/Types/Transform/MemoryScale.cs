using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
    [Image(typeof(IconScale), ColorTheme.Type.Green)]
    
    [Title("Scale")]
    [Category("Transform/Scale")]
    
    [Description("Remembers the local scale of the object")]

    [Serializable]
    public class MemoryScale : Memory
    {
        public override string Title => "Scale";

        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        public override Token GetToken(GameObject target)
        {
            return new TokenScale(target);
        }

        public override void OnRemember(GameObject target, Token token)
        {
            if (token is TokenScale tokenScale)
            {
                target.transform.localScale = tokenScale.Scale;
            }
        }
    }
}