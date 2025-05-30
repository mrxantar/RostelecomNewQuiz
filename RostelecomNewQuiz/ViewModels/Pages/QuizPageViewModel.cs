using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;

namespace RostelecomNewQuiz.ViewModels.Pages;

public partial class QuizPageViewModel : ObservableObject
{
    [ObservableProperty] private string _questionImage;
    [ObservableProperty] private ObservableCollection<string> _images = [];
    private int index = 0;
    private string path = "Resources\\Quiz";

    public QuizPageViewModel()
    {
        GetImages();
        QuestionImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Images[index]);
    }

    private void GetImages()
    {
        Images = [.. Directory.GetFiles(path)];
    }
}