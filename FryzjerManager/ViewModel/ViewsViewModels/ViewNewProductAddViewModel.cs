using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Security.Policy;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewNewProductAddViewModel : ViewModelBase.ViewModelBase
    {
        #region Komendy przyciskow
        public event Action<object> TransferData;
        private ICommand _addProduct = null;
        public ICommand AddProduct
        {
            get
            {
                if (_addProduct == null)
                    _addProduct = new ViewModelBase.RelayCommand(
                        arg => {
                            object product;
                            if (IsSingleUse)
                                product = new SingleUseProduct(0, ProductName, 0, int.Parse(ProductPrice));
                            else
                                product = new Product(0, ProductName, 0, 0, int.Parse(ProductCapacity), int.Parse(ProductPrice));
                            TransferData?.Invoke(product);
                        },
                        arg => (!string.IsNullOrEmpty(ProductName) && !string.IsNullOrEmpty(ProductPrice)) && 
                            (IsSingleUse || (!string.IsNullOrEmpty(ProductCapacity) && int.TryParse(ProductCapacity, out int x))) && int.TryParse(ProductPrice, out int z));
                return _addProduct;
            }
        }
        #endregion

        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCapacity { get; set; }
        public bool IsSingleUse { get; set; } = true;
    }
}
