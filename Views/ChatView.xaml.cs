using System.Windows;
using System.Windows.Controls;
using DbProject.ViewModels;

namespace DbProject
{
    public partial class ChatView : UserControl
    {
        
        public ChatView()
        {
            InitializeComponent();
            DataContext=new ChatViewModel();
            
        }
    }
}