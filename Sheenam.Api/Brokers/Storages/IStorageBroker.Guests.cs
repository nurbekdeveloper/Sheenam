//=======================
//Coperight(c)  Coalition  of Good  -  Hearted  Enginners 
// Free To Use Comfort and Peace 
//======================



using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial  interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync (Guest guest); 
        



    }
}
