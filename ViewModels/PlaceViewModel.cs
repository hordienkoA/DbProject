using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class PlaceViewModel:INotifyPropertyChanged
    {
        private ApplicationContext db;
        public ObservableCollection<Place> Places { get; set; }
        private Place selectedplace;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       Place place = selectedplace;
                       place.Id = 0;
                       db.Places.Add(place);
                       db.SaveChanges();
                       Places.Clear();
                       db.Places.ToList().ForEach(Places.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.Places.Remove(selectedplace);
                       db.SaveChanges();
                       Places.Clear();
                       db.Places.ToList().ForEach(Places.Add);
                   }));
        }
        
        public PlaceViewModel()
        {
            db=new ApplicationContext();
            Places=new ObservableCollection<Place>(db.Places);
        }
        
        public Place SelectedPlace
        {
            get => selectedplace;
            set
            {
                selectedplace = value;
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