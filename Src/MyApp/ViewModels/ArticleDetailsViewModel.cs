using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModels;
[QueryProperty(nameof(Article), "Article")]

public partial class ArticleDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Article article;
}
