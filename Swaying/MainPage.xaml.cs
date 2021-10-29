using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Swaying
{
    public sealed class SwayingItem
    {
        public String Title { set; get; }
    }

    public sealed class Group
    {
        public String GroupTitle { set; get; }
        public List<SwayingItem> Items { get; }

        public Group()
        {
            Items = new List<SwayingItem>();
        }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Group> _lstItems = new List<Group>();

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            InitView();
        }

        public void InitView()
        {
            Group g = null;

            for(int n = 0; n < 5; ++n)//group
            {
                g = new Group()
                {
                    GroupTitle = String.Format("Group {0}", n)
                };

                for(int m =0; m < 64; ++m)//group item
                {
                    g.Items.Add(new SwayingItem() { Title = String.Format("Item {0}", m)});
                }

                _lstItems.Add(g);
            }

            var cvs = new CollectionViewSource()
            {
                Source = _lstItems,
                IsSourceGrouped = true,
                ItemsPath = new PropertyPath(nameof(Group.Items))
            };

            gd.ItemsSource = cvs.View;
        }
    }
}
