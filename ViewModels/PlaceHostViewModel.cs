using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class PlaceHostViewModel:INotifyPropertyChanged
    {
        private ApplicationContext db;
        private PlaceHost selectedplacehost;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public ObservableCollection<PlaceHost> PlaceHosts { get; set; }
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       PlaceHost placeHost = selectedplacehost;
                       placeHost.Id = 0;
                       db.PlaceHosts.Add(placeHost);
                       db.SaveChanges();
                       PlaceHosts.Clear();
                       db.PlaceHosts.ToList().ForEach(PlaceHosts.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.PlaceHosts.Remove(selectedplacehost);
                       db.SaveChanges();
                       PlaceHosts.Clear();
                       db.PlaceHosts.ToList().ForEach(PlaceHosts.Add);
                   }));
        }
        public PlaceHostViewModel()
        {
            db=new ApplicationContext();
            PlaceHosts=new ObservableCollection<PlaceHost>(db.PlaceHosts);
           
            
        }

        public PlaceHost SelectedPlaceHost
        {
            get => selectedplacehost;
            set
            {
                selectedplacehost = value;
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