using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThiUWP.models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThiUWP.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeachContac : Page
    {
        private NoteModel noteModel = new NoteModel();
        public SeachContac()
        {
            this.InitializeComponent();
            this.Loaded += SeachContac_Loaded;
        }

        private void SeachContac_Loaded(object sender, RoutedEventArgs e)
        {
            MyListView.ItemsSource = noteModel.FindAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
