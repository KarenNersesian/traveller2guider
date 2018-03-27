using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using WebApplication5.DAL;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebApplication5.Services
{
    public class AccountService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UnavailableDate GetUnavailableDate(string dateFrom, string dateTo, string guiderId )
        {

            UnavailableDate unavailableDate = new UnavailableDate();
            try
            {
                unavailableDate.GuiderID = guiderId;
                unavailableDate.UnavailableDateEntry = DateTime.Now;
                unavailableDate.UnavailableFrom = DateTime.ParseExact(dateFrom, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                unavailableDate.UnavailableTo = DateTime.ParseExact(dateTo, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch( Exception e)
            {
                Debug.WriteLine(e.Message);

                throw;
            }

            return unavailableDate;
        }

        public List<UnavailableDate> GetUnavailableDates(string guiderId)
        {
            var dates = (from date in db.UnavailableDates
                         where date.GuiderID == guiderId
                         select date).ToList();

            return dates;
        }

        public async Task<int> InsertDbNonWorkingDayAsync(UnavailableDate unavailableDate)
        {
            try
            {
                db.UnavailableDates.Add(unavailableDate);
                await db.SaveChangesAsync();

                return 1;
            }
            catch( Exception )
            {
                throw;
            }
        }
    }
}