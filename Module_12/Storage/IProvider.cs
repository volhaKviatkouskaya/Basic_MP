using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Storage
{
    public interface IProvider
    {
        public void SaveItem(DocumentBase doc);
        public List<DocumentBase> SearchItemById(int id);
    }
}
