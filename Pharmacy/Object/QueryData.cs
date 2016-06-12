using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class QueryData
    {
        int id;
        string queryData;


        public QueryData(int id, string queryData)
        {
            this.id = id;
            this.queryData = queryData;
        }
        public int getID(){
            return id;
        }
        public void setID(int id)
        {
            this.id = id;
        }
        public string getQueryData()
        {
            return queryData;
        }
        public void setQueryData(string queryData)
        {
            this.queryData = queryData;
        }
    }
}
