using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class TourView : UserControl
    {
        public TourView()
        {
            InitializeComponent();
            DataContext=new TourViewModel();
        }
    }
}