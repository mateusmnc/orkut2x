﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace orkut2x.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabContainer : TabbedPage
    {
        public TabContainer ()
        {
            InitializeComponent();
        }
    }
}