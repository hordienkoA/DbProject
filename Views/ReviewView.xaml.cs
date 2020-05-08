using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class ReviewView : UserControl
    {
        public ReviewView()
        {
            InitializeComponent();
            DataContext=new ReviewViewModel();
        }
    }
}