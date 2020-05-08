using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class HostGuideViewModel:INotifyPropertyChanged
    {
        private ApplicationContext db;
        private HostGuide selectedhost;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public ObservableCollection<HostGuide> HostGuides { get; set; }
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       HostGuide hostGuide = selectedhost;
                       hostGuide.Id = 0;
                       db.HostGuides.Add(hostGuide);
                       db.SaveChanges();
                       HostGuides.Clear();
                       db.HostGuides.ToList().ForEach(HostGuides.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.HostGuides.Remove(selectedhost);
                       db.SaveChanges();
                       HostGuides.Clear();
                       db.HostGuides.ToList().ForEach(HostGuides.Add);
                   }));
        }
        
        
        
        
        
        public HostGuideViewModel()
        {
            db=new ApplicationContext();
            HostGuides=new ObservableCollection<HostGuide>(db.HostGuides);
           
            
        }

        public HostGuide SelectedHost
        {
            get => selectedhost;
            set
            {
                selectedhost = value;
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