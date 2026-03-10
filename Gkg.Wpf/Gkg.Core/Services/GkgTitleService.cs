namespace Gkg.Core.Services
{
    public class GkgTitleService : ITitleService
    {
        public bool SetTile(string title,out string newTitle)
        {
            bool isSet = false;
            newTitle = title;
            if (!string.IsNullOrEmpty(title))
            {
                isSet = true;
                newTitle = $"Hello {title}";
            }
            return isSet;
        }
    }
}
