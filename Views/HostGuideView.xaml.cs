using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class HostGuideView : UserControl
    {
        public HostGuideView()
        {
            InitializeComponent();
            DataContext = new HostGuideViewModel();
        }
    }
}