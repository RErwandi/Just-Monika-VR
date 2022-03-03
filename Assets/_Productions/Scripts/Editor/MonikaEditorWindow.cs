using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace JustMonika.VR
{
    public class MonikaEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("Monika/Editor")]
        private static void OpenWindow()
        {
            GetWindow<MonikaEditorWindow>().Show();
        }
        
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();

            tree.Add("Game Configs", GameConfig.Instance);
            tree.Add("Dialogue Configs", DialogueConfig.Instance);

            return tree;
        }
    }
}