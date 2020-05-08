using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class ChatViewModel:INotifyPropertyChanged
    {
        private ApplicationContext db;
        private Chat selectedchat;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public RelayCommand AddCommand
        {
            get => addCommand??
            (addCommand=new RelayCommand(obj =>
            {
                Chat chat = selectedchat;
                chat.Id = 0;
                db.Chats.Add(chat);
                db.SaveChanges();
                Chats.Clear();
                db.Chats.ToList().ForEach(Chats.Add);
            }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.Chats.Remove(selectedchat);
                       db.SaveChanges();
                       Chats.Clear();
                       db.Chats.ToList().ForEach(Chats.Add);
                   }));
        }
        
        
        public ObservableCollection<Chat> Chats { get; set; }
        
        
        public ChatViewModel()
        {
            db=new ApplicationContext();
            Chats=new ObservableCollection<Chat>(db.Chats);
           
            
        }

        public Chat SelectedChat
        {
            get => selectedchat;
            set
            {
                selectedchat = value;
                OnPropertyChanged();
            }
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}