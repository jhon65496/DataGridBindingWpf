using DataGridBindingWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using DataGridBindingWpf.Data;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
// using DataGridBindingWpf.Commands;

namespace DataGridBindingWpf.ViewModels
{
    public class IndexesViewModel : BaseVM
    {   
        DbContextIndexes _dataContextApp;
        public IndexesViewModel()
        {

            this._dataContextApp = new DbContextIndexes();
            
            LoadData();

            Indexes.CollectionChanged += Indexes_CollectionChanged;        
        }

        private void Indexes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    // item.PropertyChanged -= UpdatePrice;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    // item.PropertyChanged += UpdatePrice;
            }
            
            _dataContextApp.SaveChanges();
        }

        public void UpdatePrice()
        {

        }   

        private ObservableCollection<Index> indexes;
        public ObservableCollection<Index> Indexes
        {
            get { return indexes; }
            set 
            {
                indexes = value;

                Debug.WriteLine($"ObservableCollection<Index> Indexes -- set ");
                _dataContextApp.SaveChanges();

                RaisePropertyChanged(nameof(Indexes));
            }
        }

        public void LoadData()
        {         
            var items = this._dataContextApp.Indexes.ToList();
            Indexes = new ObservableCollection<Index>(items);
        }

    }
}
