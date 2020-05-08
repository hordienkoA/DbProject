using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class TourViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<Tour> Tours { get; set; }
        private ApplicationContext db;
        private Tour selectedtour;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       Tour tour = selectedtour;
                       tour.Id = 0;
                       db.Tours.Add(tour);
                       db.SaveChanges();
                       Tours.Clear();
                       db.Tours.ToList().ForEach(Tours.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.Tours.Remove(selectedtour);
                       db.SaveChanges();
                       Tours.Clear();
                       db.Tours.ToList().ForEach(Tours.Add);
                   }));
        }
        
        public TourViewModel()
        {
            db=new ApplicationContext();
            Tours=new ObservableCollection<Tour>(db.Tours);
           
            
        }

        public Tour SelectedTour
        {
            get => selectedtour;
            set
            {
                selectedtour = value;
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