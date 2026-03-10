using CommunityToolkit.Mvvm.ComponentModel;
using Gkg.Core.Services;

namespace Gkg.ViewModel.MainPage
{
    [ObservableObject]
    public partial class TitleBarViewModel
    {
        private readonly ITitleService titleService;
        [ObservableProperty]
        private string _title = "Gkg";

        public TitleBarViewModel(ITitleService titleService)
        {
            this.titleService = titleService;
            Task.Run(async() =>
            {
                await Task.Delay(2000);
                if (titleService.SetTile("Gkg Corp", out var newTitle))
                {
                    Title = newTitle;
                }
            });
        }
    }
}
