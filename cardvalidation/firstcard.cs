using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardvalidation
{
    class firstCard : IfirstCard
    {


        public bool Authenticate(int no, DateTime expdate, int ccv, float transamt)
        {
            CardINFOEntities db = new CardINFOEntities();
            double bal;
            if (no <= 0)
                throw new ArgumentException("card no is invald");
            else if (DateTime.Now == expdate)
                throw new ArgumentException("card expired");
            else if (ccv <= 0)
                throw new ArgumentException("ccv no. is invald");
            else
            {
                var data = db.Cardins.Where(x => x.cardNo == no && x.expdate == expdate && x.ccvno == ccv && x.balance > transamt).SingleOrDefault();
          
                if (data == null)
                    throw new ArgumentException("invalid transcation");
                else
                {
                    var olddata = (from t in db.Cardins where t.cardNo == no select t).SingleOrDefault();
                    olddata.balance = bal - transamt;

                    var res = db.SaveChanges();
                    return true;

                }

            }

        }

    }
}


