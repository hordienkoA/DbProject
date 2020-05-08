using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class TouristGuideView : UserControl
    {
        public TouristGuideView()
        {
            InitializeComponent();
            DataContext=new TouristGuideViewModel();
        }
    }
}