using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Storage;

namespace Service
{
    public interface IService
    {
        public void SaveItem(DocumentBase doc);
        public List<DocumentBase> SearchItemById(int id);
    }
}
