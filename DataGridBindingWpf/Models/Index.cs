using DataGridBindingWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataGridBindingWpfPrivate01.ViewModels;
using System.Diagnostics;

namespace DataGridBindingWpf.Models
{
    [Table("Indexes")]
    public class Index : OnPropertyChangedClass
    {
        public int Id { get; set; }


        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;

                Debug.WriteLine($"Index Name -- set ");
                

                OnPropertyChanged(nameof(Name));
            }
        }       
    }
}
