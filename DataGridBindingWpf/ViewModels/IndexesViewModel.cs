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
            // throw new NotImplementedException();
            Debug.WriteLine($"Indexes_CollectionChanged");
            Debug.WriteLine($"Indexes_CollectionChanged: --- {e.Action.ToString()}");
            _dataContextApp.SaveChanges();
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
