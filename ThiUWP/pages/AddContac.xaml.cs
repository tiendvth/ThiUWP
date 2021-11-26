using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThiUWP.entities;
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
    public sealed partial class AddContac : Page
    {
        private NoteModel noteModel = new NoteModel();
        public AddContac()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var note = new Note()
            {
               
                Name = txtname.Text,
                PhoneNumber = txtphonnumber.Text,
            };

            noteModel.Save(note);

        }
    }
}
