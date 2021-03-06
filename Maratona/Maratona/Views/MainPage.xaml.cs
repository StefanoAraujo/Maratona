﻿using Maratona.Models;
using Maratona.Services;
using Maratona.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MainViewModel(this.Navigation, usuario);
        }
    }
}
