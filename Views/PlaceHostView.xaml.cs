using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class PlaceHostView : UserControl
    {
        public PlaceHostView()
        {
            InitializeComponent();
            DataContext=new PlaceHostViewModel();
        }
    }
}