using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class PlaceView : UserControl
    {
        public PlaceView()
        {
            InitializeComponent();
            DataContext=new PlaceViewModel();
        }
    }
}