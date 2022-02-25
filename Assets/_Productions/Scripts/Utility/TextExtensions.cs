namespace JustMonika.VR
{
    public static class TextExtensions
    {
        public static string ToDialogue(this string text)
        {
            var currentText = text;
            var parsedText = currentText.Replace("[player]", GameSettings.Instance.playerName);
            return parsedText;
        }
    }
}