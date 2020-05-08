using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class TouristGuideViewModel:INotifyPropertyChanged
    {
       
        private ApplicationContext db;
        private TouristGuide selectedtouristguide;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       TouristGuide touristGuide = selectedtouristguide;
                       touristGuide.Id = 0;
                       db.TouristGuides.Add(touristGuide);
                       db.SaveChanges();
                       TouristGuides.Clear();
                       db.TouristGuides.ToList().ForEach(TouristGuides.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.TouristGuides.Remove(selectedtouristguide);
                       db.SaveChanges();
                       TouristGuides.Clear();
                       db.TouristGuides.ToList().ForEach(TouristGuides.Add);
                   }));
        }
        public ObservableCollection<TouristGuide> TouristGuides { get; set; }
        
        public TouristGuideViewModel()
        {
            db=new ApplicationContext();
            TouristGuides=new ObservableCollection<TouristGuide>(db.TouristGuides);
           
            
        }

        public TouristGuide SelectedTouristGuide
        {
            get => selectedtouristguide;
            set
            {
                selectedtouristguide = value;
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