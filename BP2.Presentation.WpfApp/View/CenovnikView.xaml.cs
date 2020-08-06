﻿using BP2.Presentation.WpfApp.ViewModel;
using System;
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
using System.Windows.Shapes;

namespace BP2.Presentation.WpfApp.View
{
    /// <summary>
    /// Interaction logic for CenovnikView.xaml
    /// </summary>
    public partial class CenovnikView : Window
    {
        public CenovnikView()
        {
            InitializeComponent();
            DataContext = new CenovnikViewModel();
        }
    }
}
