﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FryzjerManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ViewAuthors.xaml
    /// </summary>
    public partial class ViewAuthors : UserControl
    {
        public static readonly DependencyProperty vm = DependencyProperty.Register(

          "ViewModel",
          typeof(ViewModel.ViewsViewModels.ViewAuthorsViewModel),
          typeof(ViewAuthors),
          null);

        public ViewModel.ViewsViewModels.ViewAuthorsViewModel ViewModel
        {
            get { return (ViewModel.ViewsViewModels.ViewAuthorsViewModel)GetValue(vm); }
            set { SetValue(vm, value); }
        }
        public ViewAuthors()
        {
            InitializeComponent();
        }
    }
}
