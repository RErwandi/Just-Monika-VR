using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace JustMonika.VR
{
    [GlobalConfig("_Productions/Resources/Configs/")]
    public class DialogueConfig : GlobalConfig<DialogueConfig>
    {
        public List<string> dialogueCategories = new List<string>();
        
        public List<string> GetAvailableCategory => dialogueCategories.ToList();
    }
}