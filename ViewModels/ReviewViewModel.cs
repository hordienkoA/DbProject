using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DbProject.Annotations;
using DbProject.Model;

namespace DbProject.ViewModels
{
    public class ReviewViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<Review> Reviews { get; set; }
        private ApplicationContext db;
        private Review selectedreview;
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand editCommand;
        public RelayCommand AddCommand
        {
            get => addCommand??
                   (addCommand=new RelayCommand(obj =>
                   {
                       Review review = selectedreview;
                       review.Id = 0;
                       db.Reviews.Add(review);
                       db.SaveChanges();
                       Reviews.Clear();
                       db.Reviews.ToList().ForEach(Reviews.Add);
                   }));
            set => addCommand = value;
        }

        public RelayCommand DeleteCommand
        {
            get => delCommand ??
                   (delCommand = new RelayCommand(obj =>
                   {
                       db.Reviews.Remove(selectedreview);
                       db.SaveChanges();
                       Reviews.Clear();
                       db.Reviews.ToList().ForEach(Reviews.Add);
                   }));
        }
        public ReviewViewModel()
        {
            db=new ApplicationContext();
            Reviews=new ObservableCollection<Review>(db.Reviews);
           
            
        }

        public Review SelectedReview
        {
            get => selectedreview;
            set
            {
                selectedreview = value;
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