using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FryzjerManager.Model;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewActualStockViewModel : ViewModelBase.ViewModelBase
    {
        Inventory inventory = new Inventory();
        public string ProductName { get; set; }
    }
}
