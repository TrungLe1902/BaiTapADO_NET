using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_NET
{
    public interface IThemSuaXoa
    {
        void ShowAllProducts();
        void AddProduct();
        void AddCategory();
        void UpdateProduct();
        void DeleteProduct();
    }
}
