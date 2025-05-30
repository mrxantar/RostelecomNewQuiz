using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Navigation;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using RostelecomNewQuiz.Views.Pages;

namespace RostelecomNewQuiz.ViewModels.Pages;

public partial class MainPageViewModel : ObservableObject
{
    private DispatcherTimer _backgroundTimer = new DispatcherTimer();
    [ObservableProperty] private string _backgroundImage;
    [ObservableProperty] private ObservableCollection<string> _images = [];
    private int index;
    private string path = "Resources\\Background";

    private NavigationService<QuizPageViewModel> _quizPageNavigationService;
    public MainPageViewModel(NavigationService<QuizPageViewModel> quizPage)
    {
        _quizPageNavigationService = quizPage;
        GetImage();
        _backgroundTimer.Interval = TimeSpan.FromSeconds(10);
        _backgroundTimer.Tick += BackgroundTimerOnTick;
        _backgroundTimer.Start();
        SwitchImage();
    }

    private void BackgroundTimerOnTick(object? sender, EventArgs e)
    {
        if (index >= Images.Count - 1)
            index = 0;
        else
            index++;
        SwitchImage();
       
    }

    public void SwitchImage()
    {
        BackgroundImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Images[index]) ;
    }

    public void GetImage()
    {
        Images = [..Directory.GetFiles(path)];
    }

    [RelayCommand]
    private void NavigationToQuiz()
    {
        _backgroundTimer.Stop();
        _quizPageNavigationService.Navigate();
    }
}